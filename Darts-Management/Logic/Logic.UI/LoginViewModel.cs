using Darts.Data.Infrastructure;
using Darts.Data.Model.UserEntitys.DTOs;
using Darts.Logic.Core.UserCore;
using Darts.Logic.Core.Validierung;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.Models.UserModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts.Logic.UI
{
    public class LoginViewModel : ViewModelValidate
    {
        readonly AuthenticateModel authenticate;
        public LoginViewModel()
        {
            Title = "Anmeldung";
            LoginCommand = new DelegateCommand(ExecuteLoginCommand, CanExecuteCommand);
            PasswordCommand = new RelayCommand<PasswordBox>(ExecutePasswordChangedCommand);

            authenticate = new AuthenticateModel();
            Password = "";
            User = "";
        }

        private void ExecuteLoginCommand()
        {
            var Erfolgreich = new UserAPI().Authenticate(new AuthenticateDTO
            {
                Password = authenticate.Password,
                Username = authenticate.Username
            });

            if (!Erfolgreich)
            {
                SendExceptionMessage("User oder Passwort ist falsch");
            }
            else
            {
                //Messenger.Default.Send(new OpenViewMessage { ViewType = ViewType.viewWertpapierUebersicht });
                Messenger.Default.Send(new CloseViewMessage(), "Login");
            }
        }

        protected bool CanExecuteCommand()
        {
            return ValidationErrors.Count == 0;
        }

        protected override void ExecuteCleanUpCommand()
        {
            base.ExecuteCleanUpCommand();
            Messenger.Default.Send(new CloseApplicationMessage());
        }


        #region Bindings
        public ICommand LoginCommand { get; private set; }

        public string User
        {
            get { return authenticate.Username; }
            set
            {
                if (RequestIsWorking || !string.Equals(authenticate.Username, value))
                {
                    ValidateName(value);
                    authenticate.Username = value;
                    RaisePropertyChanged();
                    ((DelegateCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get { return authenticate.Password; }
            set
            {
                if (RequestIsWorking || !string.Equals(authenticate.Password, value))
                {
                    ValidatePassword(value);
                    authenticate.Password = value;
                    RaisePropertyChanged();
                    ((DelegateCommand)LoginCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public RelayCommand<PasswordBox> PasswordCommand { get; private set; }


        private void ExecutePasswordChangedCommand(PasswordBox obj)
        {
            if (obj != null)
                Password = obj.Password;
        }
        #endregion

        #region Validate
        private bool ValidateName(string name)
        {
            var Validierung = new BaseValidierung();

            bool isValid = Validierung.ValidateString(name, "Der User", out ICollection<string> validationErrors);

            AddValidateInfo(isValid, nameof(User), validationErrors);
            return isValid;
        }
        private bool ValidatePassword(string name)
        {
            var Validierung = new BaseValidierung();

            bool isValid = Validierung.ValidateString(name, "Das Password", out ICollection<string> validationErrors);

            AddValidateInfo(isValid, nameof(Password), validationErrors);
            return isValid;
        }
        #endregion
    }
}
