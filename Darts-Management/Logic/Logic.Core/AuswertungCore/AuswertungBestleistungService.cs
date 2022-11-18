using Darts.Data.Infrastructure.SpielerRepositorys;
using Darts.Data.Model.SpielerEntitys;
using Darts.Data.Types.AuswertungTypes;
using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Models.AuswertungModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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

        public ObservableCollection<AuswertungBestleistungenAllTimeModel> ErmittleBestliste(BestlisteAuswertungArt bestlisteAuswertung, BestleistungAuswertungArt bestleistungAuswertungArt)
        {
            return ErmittleBestliste(bestlisteAuswertung, bestleistungAuswertungArt, 0, 0);
        }

        public ObservableCollection<AuswertungBestleistungenAllTimeModel> ErmittleBestliste(BestlisteAuswertungArt bestlisteAuswertung, BestleistungAuswertungArt bestleistungAuswertungArt, int jahr)
        {
            return ErmittleBestliste(bestlisteAuswertung, bestleistungAuswertungArt, jahr, 0);
        }

        public ObservableCollection<AuswertungBestleistungenAllTimeModel> ErmittleBestliste(BestlisteAuswertungArt bestlisteAuswertung, BestleistungAuswertungArt bestleistungAuswertungArt, int jahr, int monat)
        {
            var ReturnList = new ObservableCollection<AuswertungBestleistungenAllTimeModel>();
            IList<Bestleistung> Bestleistungen = new List<Bestleistung>();
            switch (bestlisteAuswertung)
            {
                case BestlisteAuswertungArt.AllTime:
                    Bestleistungen = bestleistungService.LadeByAuswertungArt(bestleistungAuswertungArt);
                    break;
                case BestlisteAuswertungArt.Jahresliste:
                    Bestleistungen = bestleistungService.LadeByAuswertungArtUndJahr(bestleistungAuswertungArt, jahr);
                    break;
                case BestlisteAuswertungArt.Monatsliste:
                    Bestleistungen = bestleistungService.LadeByAuswertungArtUndJahrundMonat(bestleistungAuswertungArt, jahr, monat);
                    break;
                default:
                    break;
            }
       
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
