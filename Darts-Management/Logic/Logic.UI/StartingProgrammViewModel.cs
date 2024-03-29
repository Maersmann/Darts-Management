﻿using Darts.Data.Infrastructure;
using Darts.Logic.Core;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI
{
    public class StartingProgrammViewModel : ViewModelBasis
    {
        private bool ladeVorgangBeendet;
        public StartingProgrammViewModel()
        {
            ladeVorgangBeendet = false;
            Title = "Loading...";
            CheckServerIsOnlineCommand = new RelayCommand(() => ExecuteCheckServerIsOnlineCommand());
        }

        private async void ExecuteCheckServerIsOnlineCommand()
        {
            await Task.Run(() =>
            {
                new DBHelper().CheckServerIsOnline();
            });

            ladeVorgangBeendet = true;
            Messenger.Default.Send(new CloseViewMessage(), "StartingProgramm");
            if (GlobalVariables.DBIstErreichbar)
            {
                Messenger.Default.Send(new OpenLoginViewMessage { });
            }
            else
            {
                Messenger.Default.Send(new CloseApplicationMessage { });
            }
        }

        public ICommand CheckServerIsOnlineCommand { get; private set; }

        protected override void ExecuteCleanUpCommand()
        {
            base.ExecuteCleanUpCommand();
            if (!ladeVorgangBeendet)
                Messenger.Default.Send(new CloseApplicationMessage());
        }


    }
}
