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
        protected IList<int> vorhandenIDs;
        public ViewModelAuswahl()
        {
            NewItemCommand = new RelayCommand(ExcecuteNewItemCommand);
            AuswahlGetaetigt = false;
            vorhandenIDs = new List<int>();
        }

        protected virtual void ExcecuteNewItemCommand()
        {
            Messenger.Default.Send(new BaseStammdatenMessage<B> { State = State.Neu, ID = null, Stammdaten = GetStammdatenType(), Callback = StammdatenCallback });
        }

        protected virtual void StammdatenCallback(bool neuerEintrag, string filter) 
        { 
            if(neuerEintrag)
            {
                FilterText = filter;
                if (vorhandenIDs.Count > 0)
                {
                    LoadData(vorhandenIDs);
                }
                else
                {
                    LoadData();
                }
                
            }   
        }

        protected virtual void LoadData(IList<int> vorhandeneIDs)
        {
            this.vorhandenIDs = vorhandeneIDs;
        }
        protected override void ExecuteSucheCommand()
        {
            if (vorhandenIDs.Count > 0)
            {
                LoadData(vorhandenIDs);
            }
            else
            {
                LoadData();
            }
        }

        public ICommand NewItemCommand { get; set; }

        protected virtual B GetStammdatenType() { throw new NotImplementedException(); }

        public bool AuswahlGetaetigt { get; set; }
    }
}
