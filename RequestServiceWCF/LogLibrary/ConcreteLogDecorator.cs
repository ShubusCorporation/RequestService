using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    class ConcreteLogDecorator : AbstractLogDecorator
    {
        private Dictionary<MessageType, string> _Dict = new Dictionary<MessageType, string>()
        {
            { MessageType.MESSAGE_TRACE, "Trace : " },
            { MessageType.MESSAGE_DEBUG, "Debug : " },
            { MessageType.MESSAGE_INFO, "Info : " },
            { MessageType.MESSAGE_WARNING, "Warning : " },
            { MessageType.MESSAGE_ERROR, "Error : " },
            { MessageType.MESSAGE_FATALERROR, "Fatal : " },
        };

        // Придает дополнительную ф-ть заданному логгеру
        public override void Log(MessageType MType, string Message)
        {
            base.Log(MType, _Dict[MType] + Message);
        }
    }
}
