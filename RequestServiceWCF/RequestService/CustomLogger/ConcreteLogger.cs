using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogLibrary;
using NLog;

namespace LogLibrary
{
    class NLogLogger : AbstractLogger
    {
        private Logger _Logger = LogManager.GetCurrentClassLogger();

        public override void Log(MessageType MType, string Message)
        {
            switch(MType)
            {
                case MessageType.MESSAGE_TRACE:
                    _Logger.Trace(Message);
                    break;

                case MessageType.MESSAGE_DEBUG:
                    _Logger.Debug(Message);
                    break;

                case MessageType.MESSAGE_INFO:
                    _Logger.Info(Message);
                    break;

                case MessageType.MESSAGE_WARNING:
                    _Logger.Warn(Message);

                    break;

                case  MessageType.MESSAGE_ERROR:
                    _Logger.Error(Message);
                    break;

                case MessageType.MESSAGE_FATALERROR:
                    _Logger.Fatal(Message);
                    break;
            }
        }
    }
}
