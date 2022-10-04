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

namespace Darts.Logic.UI.UtilsViewModels
{
    public class BestaetigungViewModel : ViewModelBasis
    {
        private string beschreibung;
        public BestaetigungViewModel()
        {
            Title = "";
            beschreibung = "";
            Bestaetigt = false;
            JaCommand = new RelayCommand(() => ExecuteJaCommand());
            NeinCommand = new RelayCommand(() => ExecuteNeinCommand());
        }

        public string Beschreibung
        {
            get => beschreibung;
            set
            {
                beschreibung = value;
                RaisePropertyChanged();
            }
        }

        public bool Bestaetigt { get; private set; }

        public ICommand JaCommand { get; set; }
        public ICommand NeinCommand { get; set; }
        private void ExecuteJaCommand()
        {
            Bestaetigt = true;
            Messenger.Default.Send(new CloseViewMessage(), "Bestaetigung");
        }

        private void ExecuteNeinCommand()
        {
            Bestaetigt = false;
            Messenger.Default.Send(new CloseViewMessage(), "Bestaetigung");
        }
    }
}
