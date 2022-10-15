using Darts.Data.Types.BaseTypes;
using Darts.Data.Types.SpielerTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Core.Validierung;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.Models.SpielerModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.Messaging;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.SpielerViewModels
{
    public class BestleistungEintragenViewModel : ViewModelStammdaten<BestleistungEintragenModel, StammdatenTypes>
    {
        private readonly BestleistungService bestleistungService;
        private BestleistungHerkunft herkunft;
        private BestleistungArt art;
        private int spielerID;
        private int trainingSpielerID;

        public BestleistungEintragenViewModel()
        {
            Title = "Bestleistung eintragen";
            bestleistungService = new BestleistungService();
        }

        public void SetzeDaten(BestleistungArt bestleistungArt, BestleistungHerkunft bestleistungHerkunft, int spielerID, int trainingSpielerID)
        {
            herkunft = bestleistungHerkunft;
            art = bestleistungArt;
            this.spielerID = spielerID;
            this.trainingSpielerID = trainingSpielerID;
            switch (bestleistungArt)  
            {
                case BestleistungArt.highscore:
                    Title = "Highscore eintragen";
                    break;
                case BestleistungArt.highfinish:
                    Title = "Highfinish eintragen";
                    break;
                case BestleistungArt.shortLeg:
                    Title = "Short Leg eintragen";
                    break;
                case BestleistungArt.bullfinish:
                    Title = "Bullfinish eintragen";
                    break;
                default:
                    break;
            }
            RaisePropertyChanged(nameof(Title));
        }

        protected override StammdatenTypes GetStammdatenTyp() => StammdatenTypes.bestleistung;
        #region Commands
        protected override void ExecuteSaveCommand()
        {
            if (!int.TryParse(Data.Value, out int Value))
            {
                SendInformationMessage("Zahl konnte nicht erkannt werden");
                return;
            }

            switch (art)
            {
                case BestleistungArt.highscore:
                    if (Value > 180 || Value < 170)
                    {
                        SendInformationMessage("Highscore muss zwischen 170 und 180 liegen");
                        return;
                    }
                    break;
                case BestleistungArt.highfinish:
                    if (Value > 170 || Value < 100)
                    {
                        SendInformationMessage("Highfinish muss zwischen 100 und 170 liegen");
                        return;
                    }
                    break;
                case BestleistungArt.shortLeg:
                    if (Value > 18)
                    {
                        SendInformationMessage("Short Leg muss kleiner als 18 sein");
                        return;
                    }
                    break;
                case BestleistungArt.bullfinish:
                    SendInformationMessage("Bullfinish wird hier nicht unterstützt");
                    return;
                default:
                    break;
            }
            bestleistungService.NeueBestleistung(herkunft, art, Value, spielerID, trainingSpielerID);
            Messenger.Default.Send(new StammdatenGespeichertMessage { Erfolgreich = true, Message = "Gespeichert" }, GetStammdatenTyp());
        }

        #endregion

        #region Bindings
        public string Value
        {
            get { return Data.Value; }
            set
            {

                if (RequestIsWorking || !Equals(Data.Value, value))
                {
                    if (!ValidateValue(value))
                    {
                        if (!value.Equals("0"))
                        {
                            Data.Value = "";
                            RaisePropertyChanged();
                        }
                        return;
                    }
                    Data.Value = value;
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region Validierung

        private bool ValidateValue(string value)
        {
            var Validierung = new BaseValidierung();

            bool isValid = Validierung.ValidateAnzahl(value, out ICollection<string> validationErrors, false);

            AddValidateInfo(isValid, nameof(Value), validationErrors);
            return isValid;
        }

        #endregion

        public override void Cleanup()
        {
            Data = new BestleistungEintragenModel { Value = "" };
            RaisePropertyChanged();
            ValidateValue("");
            state = State.Neu;
        }
    }
}
