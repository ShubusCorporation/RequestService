using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using MyLog;

namespace RequestService
{
    public class FileAccessProvider : DataAccessProvider
    {
        private string _Storage = "";
        private object _Locker = new object();

        public FileAccessProvider(string ClearFileName)
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
                }
            }
            catch (Exception ex)
            {
                // Lock released by this point.
                LogWriter.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при создании FileAccessProvider. {1}", ex.Message, ex.StackTrace));
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
                LogWriter.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при загрузке коллекции данных. {1}", ex.Message, ex.StackTrace));
                throw;
            }
            return arrStr;
        }


        public override void SaveLine(string Str)
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
                LogWriter.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при сохранении экземпляра данных. {1}", ex.Message, ex.StackTrace));
                throw;
            }
        }
    }
}