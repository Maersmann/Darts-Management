using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Models.SpielerModels;
using Darts.Logic.Models.TrainingModels;
using Darts.Logic.UI.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.SpielerViewModels
{
    public class SpielerBestleistungenUebersichtViewModel : ViewModelUebersicht<SpielerBestleistungenUebersichtModel, StammdatenTypes>
    {
        private readonly BestleistungService bestleistungService;
        public SpielerBestleistungenUebersichtViewModel()
        {
            bestleistungService = new BestleistungService();
            Title = "Übersicht Bestleistungen";
        }

        protected override bool LoadDataBeimCreateAusfuehren => false;

        public void LoadData(int id)
        {
            var Bestleistungen = bestleistungService.LadeAlleFuerSpieler(id);
            Bestleistungen.OrderByDescending(o => o.GeworfenAm).ToList().ForEach(bestleistung =>
            {
                ItemList.Add(new SpielerBestleistungenUebersichtModel
                {
                    BestleistungArt = bestleistung.Art,
                    GeworfenAm = bestleistung.GeworfenAm.Value,
                    Training = bestleistung.TrainingSpieler.Training.Start.Value,
                    Value = bestleistung.Value.HasValue ? bestleistung.Value.ToString() : ""
                });
            });
        }
    }
}
