using Darts.Data.Types.BaseTypes;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI.BaseViewModels
{
    public class ViewModelStammdaten<T1, T2> : ViewModelValidate
    {
        protected State state;
        private T1 data;
        protected T1 newData;
        protected bool neuerEintragAngelegt;
        public ViewModelStammdaten()
        {
            Gespeichert = false;
            SaveCommand = new DelegateCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
            neuerEintragAngelegt = false;
            Cleanup();
        }

        protected T1 Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                RaisePropertyChanged();
            }
        }

        public T1 NewData { get => newData; }
        public bool Gespeichert { get; set; }
        public ICommand SaveCommand { get; protected set; }

        protected virtual T2 GetStammdatenTyp() { throw new NotImplementedException(); }

        protected virtual bool CanExecuteSaveCommand()
        {
            return ValidationErrors.Count == 0;
        }

        protected virtual void ExecuteSaveCommand()
        {
        }
    }
}

