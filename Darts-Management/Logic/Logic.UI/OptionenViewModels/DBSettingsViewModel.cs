using Darts.Data.Infrastructure;
using Darts.Logic.Core;
using Darts.Logic.Core.OptionenCore;
using Darts.Logic.Models.OptionenModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI.OptionenViewModels
{
    public class DBSettingsViewModel : ViewModelBasis
    {
        private readonly OPSettingsModel model;
        public DBSettingsViewModel()
        {
            model = new OPSettingsModel();
            SpeicherSettingsCommand = new RelayCommand(() => ExecuteSpeicherSettingsCommand());
            TestConnectionCommand = new RelayCommand(() => ExecuteTestConnectionCommand());
            Title = "Backend-Settings";
            SetModelData();
        }

        public void SetModelData()
        {
            BackendLogic backendLogic = new BackendLogic();
            if (backendLogic.IstINIVorhanden())
            {
                backendLogic.LoadData();
                model.DB_Password = backendLogic.GetPassword();
                model.DB_User = backendLogic.GetUser();
            }
        }

        #region Bindings
        public ICommand SpeicherSettingsCommand { get; set; }
        public ICommand TestConnectionCommand { get; set; }
        public string DB_Password
        {
            get => model.DB_Password;
            set
            {
                model.DB_Password = value;
                RaisePropertyChanged();
            }
        }
        public string DB_User
        {
            get => model.DB_User;
            set
            {
                model.DB_User = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands
        private void ExecuteSpeicherSettingsCommand()
        {
            BackendLogic backendlogic = new BackendLogic();
            backendlogic.SaveData(model.DB_User, model.DB_Password);
            SendInformationMessage("Settings gespeichert");
            GlobalVariables.DB_User = backendlogic.GetUser();
            GlobalVariables.DB_Password = backendlogic.GetPassword();
            new DBHelper().CheckServerIsOnline();
            ViewModelLocator locator = new ViewModelLocator();
            locator.Main.RaisePropertyChanged("MenuIsEnabled");

        }

        private void ExecuteTestConnectionCommand()
        {
            if (new DBHelper().TestCheckServerIsOnline(model.DB_Password, model.DB_User))
            {
                SendInformationMessage("Test Verbindung erfolgreich");
            }
            else
            {
                SendInformationMessage("Test Verbindung nicht erfolgreich");
            }
        }
        #endregion
    }
}
