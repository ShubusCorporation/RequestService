using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    class AbstractLogDecorator : AbstractLogger
    {
        protected AbstractLogger logger;

        public void SetComponent(AbstractLogger logger)
        {
            this.logger = logger;
        }

        public override void Log(MessageType MType, string Message)
        {
            if (logger != null)
            {
                logger.Log(MType, Message);
            }
        }
    }
}
