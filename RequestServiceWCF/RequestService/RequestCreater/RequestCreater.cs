using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogLibrary;

namespace RequestService
{
    public interface IRequestCreater
    {
        bool Create(Int64 UserId, RequestType requestType, object requestParams);
    }

    public class RequestCreater : IRequestCreater
    {
        ISaveStrategy _RequestSaver = null;
        DataRepository _JRepository = null;
        DataRepository _LRepository = null;
        DataRepository _SRepository = null;

        public RequestCreater(ISaveStrategy aRequestSaver, DataRepository SRepository, DataRepository LRepository, DataRepository JRepository)           
        {
            _RequestSaver = aRequestSaver;

            _JRepository = JRepository;
            _LRepository = LRepository;
            _SRepository = SRepository;
        }

        public bool Create(Int64 UserId, RequestType requestType, object requestParams)
        {
            if (_RequestSaver == null)
            {
                LogLibrary.LogWrapper.Log(LogLibrary.MessageType.MESSAGE_ERROR, "Не задана стратегия сохранения заявок");
                return false;
            }
            BaseRequest concreteRequest = null;

            switch (requestType)
            {
                case RequestType.REQUEST_JUSTICE:
                    {
                        concreteRequest = new GenericRequest<JusticeRequestParams>(UserId, (JusticeRequestParams)requestParams);
                        _RequestSaver.SetRepository(_JRepository);
                    }
                    break;

                case RequestType.REQUEST_LEARNING:
                    {
                        concreteRequest = new GenericRequest<LearningRequestParams>(UserId, (LearningRequestParams)requestParams);
                        _RequestSaver.SetRepository(_LRepository);
                    }
                    break;

                case RequestType.REQUEST_SELDON:
                    {
                        concreteRequest = new GenericRequest<SeldonRequestParams>(UserId, (SeldonRequestParams)requestParams);
                        _RequestSaver.SetRepository(_SRepository);                        
                    }
                    break;
                default:
                    LogWrapper.Log(MessageType.MESSAGE_ERROR, "Передан неподдерживаемый тип заявки");
                    return false;
            }
            return _RequestSaver.SaveRequest(concreteRequest);
        }
    }
}