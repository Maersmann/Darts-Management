using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Darts.Logic.Core;
using Darts.Logic.UI.BaseViewModels;
using System;
using System.Windows.Input;
using Darts.Data.Infrastructure;
using Darts.Logic.Core.OptionenCore;
using Darts.Logic.Messages.BaseMessages;

namespace Darts.Logic.UI
{
    public class MainViewModel : ViewModelBasis
    {
        public MainViewModel()
        {
            Title = "Darts";
            GlobalVariables.DBIstErreichbar = false;
            GlobalVariables.DB_Password = "";
            GlobalVariables.DB_User = "";
            OpenStartingViewCommand = new RelayCommand(() => ExecuteOpenStartingViewCommand());
        }


        public ICommand OpenStartingViewCommand { get; private set; }

        private void ExecuteOpenStartingViewCommand()
        {
            BackendLogic backendlogic = new BackendLogic();
            if (!backendlogic.IstINIVorhanden())
            {
                Messenger.Default.Send(new OpenKonfigurationViewMessage { });
            }
            backendlogic.LoadData();
            GlobalVariables.DB_Password = backendlogic.GetPassword();
            GlobalVariables.DB_User = backendlogic.GetUser();

            Messenger.Default.Send(new OpenStartingViewMessage { });
        }

    }
}