using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Darts.Logic.Core;
using Darts.Logic.UI.BaseViewModels;
using System;
using System.Windows.Input;

namespace Darts.Logic.UI
{
    public class MainViewModel : ViewModelBasis
    {
        public MainViewModel()
        {
            Title = "Aktienübersicht";
            OpenConnectionCommand = new RelayCommand(() => ExecuteOpenConnectionCommand());
        }


        public ICommand OpenConnectionCommand { get; private set; }



        private void ExecuteOpenConnectionCommand()
        {
            var db = new DatabaseAPI();
            db.AktualisereDatenbank();
        }

    }
}