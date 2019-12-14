using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestService;

namespace RequestServiceTest
{
    public class RequestServiceHost : ServiceBaseCustom
    {
        public void Start(string[] args)
        {
            base.OnStart(args);
        }

        public new void Stop()
        {
            base.OnStop();
        }

        public RequestServiceHost()
        {
            this.ServiceName = "RequestService";
        }
    }
}
