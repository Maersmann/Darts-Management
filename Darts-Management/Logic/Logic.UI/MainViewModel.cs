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
using Darts.Data.Types.BaseTypes;

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
            OpenSpielerUebersichtCommand = new RelayCommand(() => ExecuteOpenViewCommand(ViewType.SpielerUebersicht));
            OpenAktuellesTrainingCommand = new RelayCommand(() => ExecuteOpenViewCommand(ViewType.AktuellesTraining));
        }


        public ICommand OpenStartingViewCommand { get; private set; }
        public ICommand OpenSpielerUebersichtCommand { get; private set; }
        public ICommand OpenAktuellesTrainingCommand { get; private set; }

        private void ExecuteOpenViewCommand(ViewType viewType)
        {
            Messenger.Default.Send(new OpenViewMessage { ViewType = viewType });
        }

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