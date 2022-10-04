using Darts.Logic.Messages.BaseMessages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts.Logic.UI.BaseViewModels
{
    public class ViewModelBasis : ViewModelBase
    {
        private bool dataIsLoading;
        public ViewModelBasis()
        {
            messageToken = "";
            RequestIsWorking = false;
            CleanUpCommand = new RelayCommand(() => ExecuteCleanUpCommand());
            CloseWindowCommand = new RelayCommand<Window>(ExecuteCloseWindowCommand);
        }

        protected string messageToken;
        public string Title { get; protected set; }
        public virtual string MessageToken { set => messageToken = value; }


        public ICommand CleanUpCommand { get; set; }
        public RelayCommand<Window> CloseWindowCommand { get; private set; }


        protected virtual void ExecuteCleanUpCommand()
        {
            Cleanup();
        }
        protected virtual void ExecuteCloseWindowCommand(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        public bool RequestIsWorking
        {
            set
            {
                dataIsLoading = value;
                RaisePropertyChanged();
            }
            get => dataIsLoading;
        }


        public static void SendExceptionMessage(string inException)
        {
            Messenger.Default.Send(new ExceptionMessage { Message = inException });
        }

        public static void SendInformationMessage(string informationMessage)
        {
            Messenger.Default.Send(new InformationMessage { Message = informationMessage });
        }
    }
}
