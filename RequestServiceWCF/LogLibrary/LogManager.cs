using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NLog;

/* The simplest Nlog config.
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <variable name="logDirectory" value="${basedir}/Logs/${shortdate}" />

  <targets>
    <target xsi:type="File"
            name="debug"
            fileName="c:\temp\debug.txt"
            layout="${longdate} ${uppercase:${level}} ${message}"
  />
  </targets>

  <rules>
    <logger name="*" minlevel="Trace" writeTo="debug" />
  </rules>
</nlog>
 */

namespace MyLog
{
    public enum MessageType
    {
        MESSAGE_TRACE,
        MESSAGE_DEBUG,
        MESSAGE_INFO,
        MESSAGE_WARNING,
        MESSAGE_ERROR,
        MESSAGE_FATALERROR
    };

    public static class LogWriter
    {
        private static Logger _Logger = LogManager.GetCurrentClassLogger();
        private static Dictionary<MessageType, string> _Dict = new Dictionary<MessageType, string>()
        {
            { MessageType.MESSAGE_TRACE, "Trace : " },
            { MessageType.MESSAGE_DEBUG, "Debug : " },
            { MessageType.MESSAGE_INFO, "Info : " },
            { MessageType.MESSAGE_WARNING, "Warning : " },
            { MessageType.MESSAGE_ERROR, "Error : " },
            { MessageType.MESSAGE_FATALERROR, "Fatal : " },
        };

        private delegate void OperationLog(string msg);
        private static Dictionary<MessageType, OperationLog> _Operations = new Dictionary<MessageType, OperationLog>()
        {
            { MessageType.MESSAGE_TRACE, _Logger.Trace },
            { MessageType.MESSAGE_DEBUG,  _Logger.Debug },
            { MessageType.MESSAGE_INFO, _Logger.Info },
            { MessageType.MESSAGE_WARNING, _Logger.Warn },
            { MessageType.MESSAGE_ERROR, _Logger.Error },
            { MessageType.MESSAGE_FATALERROR, _Logger.Fatal },
        };

        public static void Log(MessageType MType, string Message)
        {
            // StringBuilder is not thread-save.
            // http://stackoverflow.com/questions/8831385/is-nets-stringbuilder-thread-safe
            StringBuilder sb = new StringBuilder();

            sb.Append(_Dict[MType]);
            sb.Append(Message);
            _Operations[MType](sb.ToString());
            sb.Clear();
        }
    }
}