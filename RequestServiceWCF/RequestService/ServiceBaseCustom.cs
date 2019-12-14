using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Web;
using LogLibrary;


namespace RequestService
{
    public class ServiceBaseCustom : ServiceBase
    {
        public ServiceHost serviceHost = null;

        public ServiceBaseCustom()
        {
            ServiceName = "RequestService";
        }

        public static void Main()
        {
            ServiceBase.Run(new ServiceBaseCustom());
        }

        protected override void OnStart(string[] args)
        {
            LogWrapper.SetLogger(new NLogLogger());
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);

            if (serviceHost != null)
            {
                serviceHost.Close();
            }            
            IAccountValidator accValidator = new AccountValidator(
                        new AccountProvideStrategy(
                            new FileRepository("Accounts.db")));

            RequestServiceImpl requestServiceImpl = new RequestServiceImpl();
            requestServiceImpl.SetAccountValidator(accValidator);

            DataRepository JRepository = new FileRepository("JusticeRequests.db");
            DataRepository LRepository = new FileRepository("LearningRequests.db");
            DataRepository SRepository = new FileRepository("SeldonRequests.db");

            requestServiceImpl.SetRequestCreater(new RequestCreater(new RequestSaver(), SRepository, LRepository, JRepository));

            IGenericLoader<GenericRequest<SeldonRequestParams>> SLoader = new RequestLoader<GenericRequest<SeldonRequestParams>>(SRepository);
            IGenericLoader<GenericRequest<JusticeRequestParams>> JLoader = new RequestLoader<GenericRequest<JusticeRequestParams>>(JRepository);
            IGenericLoader<GenericRequest<LearningRequestParams>> LLoader = new RequestLoader<GenericRequest<LearningRequestParams>>(LRepository);

            requestServiceImpl.SetRequestProvider(new RequestProvider(SLoader, LLoader, JLoader));
            serviceHost = new ServiceHost(requestServiceImpl);

            ///////////////////////////////////////////////////////////////////////////////////
            ContractDescription cd = serviceHost.Description.Endpoints[0].Contract;
            OperationDescription myOperationDescription = cd.Operations.Find("Create");

            DataContractSerializerOperationBehavior serializerBehavior = myOperationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();

            if (serializerBehavior == null)
            {
                serializerBehavior = new DataContractSerializerOperationBehavior(myOperationDescription);
                myOperationDescription.Behaviors.Add(serializerBehavior);
            }
            serializerBehavior.DataContractResolver = new CustomRequestResolver();
            ///////////////////////////////////////////////////////////////////////////////////

            serviceHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new RequestServicePasswordValidator();
            (serviceHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator as RequestServicePasswordValidator).SetPasswordValidator(accValidator);
            serviceHost.Open();
        }


        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }

        protected void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;

            if ((ex != null))
            {
                LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при запуске сервиса {1}", ex.Message, ex.StackTrace));
                throw ex;
            }
        }
    }
}