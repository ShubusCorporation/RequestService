using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.Web;
using LogLibrary;

namespace RequestService
{
    public class RequestServicePasswordValidator : UserNamePasswordValidator
    {
        private IAccountValidator _AccountValidator = null;

        public void SetPasswordValidator(IAccountValidator service)
        {
            this._AccountValidator = service;
        }
    

        public override void Validate(string UserName, string Password)
        {
            if (this._AccountValidator == null)
            {
                LogWrapper.Log(MessageType.MESSAGE_ERROR, "Ошибка проверки входа пользователя : Валидатор аккаунтов не задан");
                throw new SecurityTokenException();
            }
            try
            {
                if (_AccountValidator.Validate(UserName, Password) == false)
                {
                    throw new SecurityTokenException();
                }
            }
            catch (Exception ex)
            {
                LogWrapper.Log(MessageType.MESSAGE_FATALERROR, string.Format("Исключение {0} при попытке валидации пользователя {1} : {2}", ex.Message, UserName, ex.StackTrace));
                throw;
            }
        }
    }
}