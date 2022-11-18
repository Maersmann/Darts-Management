using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Core.TrainingCore;
using Darts.Logic.Models.TrainingModels;
using Darts.Logic.UI.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.TrainingViewModels
{
    public class TrainingBestleistungenUebersichtViewModel : ViewModelUebersicht<TrainingBestleistungenUebersichtModel, StammdatenTypes>
    {
        private readonly BestleistungService bestleistungService;
        public TrainingBestleistungenUebersichtViewModel()
        {
            bestleistungService = new BestleistungService();
            Title = "Übersicht Bestleistungen";
        }

        protected override bool LoadDataBeimCreateAusfuehren => false;

        public void LoadData(int id)
        {
            var Bestleistungen = bestleistungService.LadeAlleFuerTraining(id);
            Bestleistungen.OrderByDescending(o => o.GeworfenAm).ToList().ForEach(bestleistung =>
            {
                ItemList.Add(new TrainingBestleistungenUebersichtModel
                {
                    BestleistungArt = bestleistung.Art,
                    GeworfenAm = bestleistung.GeworfenAm.Value,
                    Name = bestleistung.Spieler.Vorname + " " + bestleistung.Spieler.Name,
                    Value = bestleistung.Value.HasValue ? bestleistung.Value.ToString() : ""
                });
            });
        }
    }
}
