using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Core.TrainingCore;
using Darts.Logic.Models.SpielerModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.SpielerViewModels
{
    public class SpielerUebersichtViewModel : ViewModelUebersicht<SpielerUebersichtModel, StammdatenTypes>
    {
        public SpielerUebersichtViewModel()
        {
            Title = "Übersicht aller Spieler";
        }

        protected override int GetID() => SelectedItem.ID;
        protected override StammdatenTypes GetStammdatenTyp() => StammdatenTypes.spieler;


        protected override void LoadData()
        {
            ItemList = new SpielerService().LadeFuerUebersicht();
        }

        protected override void ExecuteEntfernenCommand()
        {
            new SpielerService().Entfernen(SelectedItem.ID);
            base.ExecuteEntfernenCommand();
        }
    }
}