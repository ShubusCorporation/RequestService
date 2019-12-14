using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using LogLibrary;

namespace RequestService
{
    [DataContract]
    public enum RequestType
    {
        [EnumMember]
        REQUEST_SELDON,
        [EnumMember]
        REQUEST_JUSTICE,
        [EnumMember]
        REQUEST_LEARNING
    }

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class RequestServiceImpl : IRequestService, IRegisterService
    {
        IAccountValidator _AccountValidator = null;
        IRequestCreater _RequestCreater = null;
        IRequestProvider _RequestProvider = null;

        public void SetAccountValidator(IAccountValidator accValidator)
        {
            _AccountValidator = accValidator;
        }

        public void SetRequestCreater(IRequestCreater aCreater)
        {
            _RequestCreater = aCreater;
        }

        public void SetRequestProvider(IRequestProvider aRequestProvider)
        {
            _RequestProvider = aRequestProvider;
        }

        public bool Create(Int64 UserId, RequestType requestType, object requestParams)
        {
            if (_RequestCreater == null)
            {
                LogWrapper.Log(MessageType.MESSAGE_ERROR, "Ошибка создания : Метод создания заявок не задан");
                return false;
            }
            return _RequestCreater.Create(UserId, requestType, requestParams);
        }

        public UserRequestCollection GetRequests(Int64 UserId)
        {
            if (_RequestProvider == null)
            {
                LogWrapper.Log(MessageType.MESSAGE_ERROR, "Ошибка : Стратегии предоставления данных не заданы");
                return new UserRequestCollection();
            }
            return _RequestProvider.GetRequests(UserId);
        }
        
        public bool Register(Int64 aUserId)
        {
            if (_AccountValidator == null)
            {
                LogWrapper.Log(MessageType.MESSAGE_ERROR, "Ошибка регистрации : Валидатор аккаунтов не задан");
                throw new SecurityTokenException();
            }
            return _AccountValidator.RegisterAccount(aUserId);
        }
    }
}
