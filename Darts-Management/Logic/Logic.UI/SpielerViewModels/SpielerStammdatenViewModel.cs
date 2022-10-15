using Darts.Data.Model.SpielerEntitys;
using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Core.Validierung;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.Models.SpielerModels;
using Darts.Logic.UI.BaseViewModels;
using Darts.Logic.UI.InterfaceViewModels;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.SpielerViewModels
{
    public class SpielerStammdatenViewModel : ViewModelStammdaten<SpielerStammdatenModel, StammdatenTypes>, IViewModelStammdaten
    {
        private readonly SpielerService spielerService;
        private string name;
        public SpielerStammdatenViewModel()
        {
            Title = "Stammdaten Spieler";
            spielerService = new SpielerService();
            name = "";
        }

        public void ZeigeStammdatenAn(int id)
        {
            RequestIsWorking = true;

            var Spieler = spielerService.LadeByID(id);

            Data.ID = Spieler.ID;
            Name = Spieler.Name;
            Vorname = Spieler.Vorname;
            state = State.Bearbeiten;
            RequestIsWorking = false;
        }
        protected override StammdatenTypes GetStammdatenTyp() => StammdatenTypes.spieler;
        #region Commands
        protected override void ExecuteSaveCommand()
        {
            spielerService.Speichern(new Spieler
            {
                ID = Data.ID,
                Name = Data.Name,
                Vorname = Data.Vorname
            });
            name = Data.Vorname + " " + Data.Name;
            neuerEintragAngelegt = true;
            Messenger.Default.Send(new StammdatenGespeichertMessage { Erfolgreich = true, Message = "Gespeichert" }, GetStammdatenTyp());
        }

        #endregion

        #region Bindings
        public string Name
        {
            get { return Data.Name; }
            set
            {

                if (RequestIsWorking || !Equals(Data.Name, value))
                {
                    Data.Name = value;
                    ValidateName(value);
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                    base.RaisePropertyChanged();
                }
            }
        }
        public string Vorname
        {
            get => Data.Vorname;
            set
            {

                if (RequestIsWorking || !Equals(Data.Vorname, value))
                {
                    Data.Vorname = value;
                    ValidateVorname(value);
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                    base.RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region Validierung

        private bool ValidateName(string name)
        {
            var Validierung = new BaseValidierung();

            bool isValid = Validierung.ValidateString(name, "Name", out ICollection<string> validationErrors);

            AddValidateInfo(isValid, nameof(Name), validationErrors);
            return isValid;
        }

        private bool ValidateVorname(string vorname)
        {
            var Validierung = new BaseValidierung();

            bool isValid = Validierung.ValidateString(vorname, "Vorname", out ICollection<string> validationErrors);

            AddValidateInfo(isValid, nameof(Vorname), validationErrors);
            return isValid;
        }
        #endregion

        public override void Cleanup()
        {
            Data = new SpielerStammdatenModel { ID  = 0 };
            RaisePropertyChanged();
            ValidateName("");
            ValidateVorname("");
            state = State.Neu;
        }

        public bool NeuerEintragAngelegt() => neuerEintragAngelegt;

        public string Filter() => name;
    }
}
