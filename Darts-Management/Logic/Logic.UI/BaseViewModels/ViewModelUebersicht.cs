﻿using Darts.Data.Types.BaseTypes;
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
    public class ViewModelUebersicht<T1, T2> : ViewModelBasis
    {
        private T1 selectedItem;
        private ObservableCollection<T1> itemList;

        public ViewModelUebersicht()
        {
            EntfernenCommand = new DelegateCommand(ExecuteEntfernenCommand, CanExecuteCommand);
            NeuCommand = new RelayCommand(() => ExecuteNeuCommand());
            BearbeitenCommand = new DelegateCommand(ExecuteBearbeitenCommand, CanExecuteCommand);
            itemList = new ObservableCollection<T1>();
        }


        protected virtual int GetID() { return 0; }
        protected virtual T2 GetStammdatenTyp() { throw new NotImplementedException(); }

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

        public ICommand NeuCommand { get; protected set; }
        public ICommand BearbeitenCommand { get; protected set; }
        public ICommand EntfernenCommand { get; protected set; }
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
        }
        protected virtual void ExecuteBearbeitenCommand()
        {
            Messenger.Default.Send(new BaseStammdatenMessage<T2> { State = State.Bearbeiten, ID = GetID(), Stammdaten = GetStammdatenTyp() });
        }
        protected virtual void ExecuteNeuCommand()
        {
            Messenger.Default.Send(new BaseStammdatenMessage<T2> { State = State.Neu, ID = null, Stammdaten = GetStammdatenTyp() });
        }

        #endregion
    }
}
