using Darts.Data.Types.BaseTypes;
using Darts.Logic.Messages.BaseMessages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI.BaseViewModels
{
    public class ViewModelAuswahl<T, B> : ViewModelUebersicht<T, B>
    {

        public ViewModelAuswahl()
        {
            NewItemCommand = new RelayCommand(ExcecuteNewItemCommand);
            AuswahlGetaetigt = false;
        }

        protected virtual void ExcecuteNewItemCommand()
        {
            Messenger.Default.Send(new BaseStammdatenMessage<B> { State = State.Neu, ID = null, Stammdaten = GetStammdatenType() });
        }
        public ICommand NewItemCommand { get; set; }

        protected virtual B GetStammdatenType() { throw new NotImplementedException(); }

        public bool AuswahlGetaetigt { get; set; }
    }
}
