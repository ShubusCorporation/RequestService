using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public abstract class AbstractLogger
    {
        public abstract void Log(MessageType MType, string Message);     
    }
}
