using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Web;

namespace RequestService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private readonly ServiceProcessInstaller _installProcess;
        private readonly ServiceInstaller _installService;

        public ProjectInstaller()
        {
            _installProcess = new ServiceProcessInstaller();
            _installProcess.Account = ServiceAccount.LocalSystem;

            _installService = new ServiceInstaller();
            _installService.StartType = ServiceStartMode.Automatic;

            _installService.Installers.Clear();

            Installers.Add(_installProcess);
            Installers.Add(_installService);
        }

        public override void Install(IDictionary stateSaver)
        {
            string svcName = Context.Parameters["RequestService"];

            if (String.IsNullOrEmpty(svcName))
            {
                throw new ArgumentException("Missing required parameter 'RequestService'.");
            }

            _installService.ServiceName = svcName;
            _installService.DisplayName = svcName;
            stateSaver.Add("RequestService", svcName);

            base.Install(stateSaver);
        }

        public override void Rollback(IDictionary savedState)
        {
            string svcName = (string)savedState["RequestService"];
            _installService.ServiceName = svcName;
            base.Rollback(savedState);
        }

        public override void Uninstall(IDictionary savedState)
        {
            string svcName = (string)savedState["RequestService"];
            _installService.ServiceName = svcName;
            base.Uninstall(savedState);
        }
    }
}