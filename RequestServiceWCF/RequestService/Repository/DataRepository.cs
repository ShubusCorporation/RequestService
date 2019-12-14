using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestService
{
    //  Abstract classes should be used primarily for objects that are closely related,
    //  whereas interfaces are best suited for providing common functionality to unrelated classes.
    //  https://msdn.microsoft.com/en-us/library/scsyfw1d%28v=vs.71%29.aspx

    public abstract class DataRepository
    {
        public abstract string[] LoadLines();
        public abstract void SaveLine(string Str);
    }
}