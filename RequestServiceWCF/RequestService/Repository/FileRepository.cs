using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LogLibrary;

namespace RequestService
{
    public class FileRepository : DataRepository
    {
        private string _Storage = "";
        private object _Locker = new object();
        BlockingCollection<string> _Conveyer = new BlockingCollection<string>();

        public FileRepository(string ClearFileName)
        {
            try
            {
                lock (_Locker)
                {
                    _Storage = AppDomain.CurrentDomain.BaseDirectory + ClearFileName;

                    if (File.Exists(_Storage) == false)
                    {
                        File.Create(_Storage).Close();
                    }
                    Task.Factory.StartNew(DoSave, TaskCreationOptions.LongRunning);
                }
            }
            catch (Exception ex)
            {
                LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при создании FileAccessProvider. {1}", ex.Message, ex.StackTrace));
                throw;
            }
        }


        public override string[] LoadLines()
        {
            string[] arrStr = null;

            try
            {
                lock (_Locker)
                {
                    arrStr = File.ReadAllLines(_Storage);
                }
            }
            catch (Exception ex)
            {
                LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при загрузке коллекции данных. {1}", ex.Message, ex.StackTrace));
                throw;
            }
            return arrStr;
        }


        public override void SaveLine(string Str)
        {
            _Conveyer.Add(Str);
        }

        // http://stackoverflow.com/questions/23522258/writing-to-file-in-a-thread-safe-manner
        private void DoSave()
        {
            foreach (var Str in this._Conveyer.GetConsumingEnumerable())
            {
                try
                {
                    lock (_Locker)
                    {
                        File.AppendAllLines(_Storage, new string[] { Str }, Encoding.UTF8);
                    }
                }
                catch (Exception ex)
                {
                    LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при сохранении экземпляра данных. {1}", ex.Message, ex.StackTrace));
                    throw;
                }
            }
        }
    }
}