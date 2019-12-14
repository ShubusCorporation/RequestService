using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogLibrary;

// На базе проекта EmptyWCFServiceCS

namespace RequestServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RequestServiceHost");
            Console.WriteLine();

            try
            {
                if ((args == null) || (args.Length == 0))
                {
                    RequestServiceHost serviceWrapper = new RequestServiceHost();
                    serviceWrapper.Start(null);
                    Console.WriteLine("Started");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter for exit");
                    Console.ReadLine();
                    serviceWrapper.Stop();
                }
                else
                {
                    string cmd = args[0].ToLower().Trim();
                    string fileName = args.Length > 1 ? args[1].ToLower().Trim() : null;
                    switch (cmd)
                    {
                        case "/install":
                            InstallService(fileName);
                            break;
                        case "/uninstall":
                            UninstallService(fileName);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} на старте : {1}", ex.Message, ex.StackTrace));
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        public static string GetServiceFileName()
        {
            return Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "RequestService.exe");
        }

        public static void InstallService(string filename = null)
        {
            Console.WriteLine("Installing service...");
            string[] commandLine = commandLine = new string[1];
            commandLine[0] = "/servicename=" + GetServiceName(filename);
            IDictionary savedState = new Hashtable();

            AssemblyInstaller installer = new AssemblyInstaller(GetServiceFileName(), commandLine);
            installer.Install(savedState);
            installer.Commit(savedState);
            Console.WriteLine("Complete.");
            LogWrapper.Log(MessageType.MESSAGE_DEBUG, "Инсталляция завершена успешно)");
        }

        public static void UninstallService(string filename = null)
        {
            Console.WriteLine("Uninstalling service...");
            string[] commandLine = new string[0];
            //commandLine[0] = "/u";
            IDictionary savedState = new Hashtable();

            AssemblyInstaller installer = new AssemblyInstaller(GetServiceFileName(), commandLine);
            installer.Uninstall(savedState);
            //installer.Commit(savedState);
            Console.WriteLine("Complete.");
            LogWrapper.Log(MessageType.MESSAGE_DEBUG, "Деинсталляция прошла успешно");
        }

        public static string GetServiceName(string filename)
        {
            return string.IsNullOrEmpty(filename) ? Path.GetFileNameWithoutExtension(GetServiceFileName()) + "Windows" : filename;
        }
    }
}
