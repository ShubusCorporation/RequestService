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

namespace LogLibrary
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

    // LogWrapper не может быть декоратором, т. к. логгер должен быть статическим, а статические класса не могут наследовать от абстрактных.
    // т. о., LogWrapper не может наследовать от AbstractLogDecorator

    public static class LogWrapper
    {
        static ConcreteLogDecorator logDecorator = new ConcreteLogDecorator();

        static public void SetLogger(AbstractLogger logger)
        {
            if (logger != null)
            {
                logDecorator.SetComponent(logger);
            }
        }

        public static void Log(MessageType MsgType, string Str)
        {
            if (logDecorator != null)
            {
                logDecorator.Log(MsgType, Str);
            }
        }
    }    
}