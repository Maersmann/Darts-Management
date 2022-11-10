using Darts.Data.Infrastructure.SpielerRepositorys;
using Darts.Data.Model.SpielerEntitys;
using Darts.Data.Types.AuswertungTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Models.AuswertungModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Core.AuswertungCore
{
    public class AuswertungBestleistungService
    {
        private BestleistungService bestleistungService;

        public AuswertungBestleistungService()
        {
            bestleistungService = new BestleistungService();
        }

        public ObservableCollection<AuswertungBestleistungenAllTimeModel> ErmittleAllTime(BestleistungAuswertungArt bestleistungAuswertungArt)
        {
            var ReturnList = new ObservableCollection<AuswertungBestleistungenAllTimeModel>();

            IList<Bestleistung> Bestleistungen = bestleistungService.LadeByAuswertungArt(bestleistungAuswertungArt);
            
            Bestleistungen.GroupBy(g => g.Spieler).OrderByDescending(o => o.Count()).ToList().ForEach(x => ReturnList.Add(new AuswertungBestleistungenAllTimeModel { Anzahl = x.Count(), Name = x.Key.Vorname + " " + x.Key.Name }));

            int AnzahlVorheriger = 0;
            int AktuellerPlatz = 1;
            ReturnList.ToList().ForEach(x =>
            {
                if (AnzahlVorheriger > x.Anzahl)
                {
                    AktuellerPlatz++;
                }
                x.Platz = AktuellerPlatz;
                AnzahlVorheriger = x.Anzahl;
            });

            return ReturnList;
        }
    }
}
