using Darts.Data.Types.BaseTypes;
using Darts.Logic.Messages.BaseMessages;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI.BaseViewModels
{
    public class ViewModelUebersicht<T1, T2> : ViewModelValidate
    {
        private T1 selectedItem;
        private ObservableCollection<T1> itemList;
        private string filtertext;

        public ViewModelUebersicht()
        {
            EntfernenCommand = new DelegateCommand(ExecuteEntfernenCommand, CanExecuteCommand);
            NeuCommand = new RelayCommand(() => ExecuteNeuCommand());
            BearbeitenCommand = new DelegateCommand(ExecuteBearbeitenCommand, CanExecuteCommand);
            SucheCommand = new RelayCommand(() => ExecuteSucheCommand());
            itemList = new ObservableCollection<T1>();
            filtertext = "";
            if (LoadDataBeimCreateAusfuehren)
            {
                LoadData();
            }
        }

        protected virtual int GetID() { return 0; }
        protected virtual T2 GetStammdatenTyp() { throw new NotImplementedException(); }
        protected virtual void LoadData() { throw new NotImplementedException(); }
        protected virtual bool LoadDataBeimCreateAusfuehren => true;

        #region Bindings

        public ObservableCollection<T1> ItemList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
                RaisePropertyChanged();
            }
        }

        public T1 SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
                ((DelegateCommand)BearbeitenCommand).RaiseCanExecuteChanged();
                ((DelegateCommand)EntfernenCommand).RaiseCanExecuteChanged();
            }
        }

        public string FilterText
        {
            get
            {
                return filtertext;
            }
            set
            {
                filtertext = value;
                RaisePropertyChanged();
            }
        }

        public ICommand NeuCommand { get; protected set; }
        public ICommand BearbeitenCommand { get; protected set; }
        public ICommand EntfernenCommand { get; protected set; }
        public ICommand SucheCommand { get; protected set; }
        #endregion

        #region Commands
        protected virtual bool CanExecuteCommand()
        {
            return SelectedItem != null;
        }
        protected virtual void ExecuteEntfernenCommand()
        {
            ItemList.Remove(SelectedItem);
            RaisePropertyChanged("ItemList");
            LoadData();
        }
        protected virtual void ExecuteBearbeitenCommand()
        {
            Messenger.Default.Send(new BaseStammdatenMessage<T2> { State = State.Bearbeiten, ID = GetID(), Stammdaten = GetStammdatenTyp() });
            LoadData();
        }
        protected virtual void ExecuteNeuCommand()
        {
            Messenger.Default.Send(new BaseStammdatenMessage<T2> { State = State.Neu, ID = null, Stammdaten = GetStammdatenTyp() });
            LoadData();
        }

        protected virtual void ExecuteSucheCommand()
        {
            LoadData();
        }

        #endregion
    }
}
