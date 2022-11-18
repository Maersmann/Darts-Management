using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Core.SpielerCore.Exceptions;
using Darts.Logic.Core.TrainingCore;
using Darts.Logic.Messages.SpielerMessages;
using Darts.Logic.Messages.TrainingMessages;
using Darts.Logic.Models.SpielerModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI.SpielerViewModels
{
    public class SpielerUebersichtViewModel : ViewModelUebersicht<SpielerUebersichtModel, StammdatenTypes>
    {
        public SpielerUebersichtViewModel()
        {
            Title = "Übersicht aller Spieler";
            BestleistungenCommand = new RelayCommand(() => ExecuteBestleistungenCommand());
        }

        protected override int GetID() => SelectedItem.ID;
        protected override StammdatenTypes GetStammdatenTyp() => StammdatenTypes.spieler;


        protected override void LoadData()
        {
            ItemList.Clear();
            var Spieler = new SpielerService().LadeAlle();
            Spieler.ToList().ForEach(spieler => 
            {
                ItemList.Add(new SpielerUebersichtModel
                {
                    ID = spieler.ID,
                    Name = spieler.Name,
                    Vorname = spieler.Vorname
                });
            });
        }

        public ICommand BestleistungenCommand { get; set; }

        protected override void ExecuteEntfernenCommand()
        {
            try
            {
                new SpielerService().Entfernen(SelectedItem.ID);
                base.ExecuteEntfernenCommand();
            }
            catch (SpielerImTrainingVorhandenException)
            {
                SendExceptionMessage("Spieler hat schon an ein Training teilgenommen");
            }

        }

        private void ExecuteBestleistungenCommand()
        {
            Messenger.Default.Send(new OpenBestleistungenVomSpielerMessage { ID = GetID() }, "SpielerUebersicht");
        }
    }
}