using Darts.Data.Infrastructure.SpielerRepositorys;
using Darts.Data.Model.SpielerEntitys;
using Darts.Data.Types.AuswertungTypes;
using Darts.Data.Types.SpielerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Core.SpielerCore
{
    public class BestleistungService
    {
        private readonly BestleistungRepository bestleistungRepository;

        public BestleistungService()
        {
            bestleistungRepository = new BestleistungRepository();
        }

        public void NeueBestleistung(BestleistungHerkunft herkunft, BestleistungArt art, int value, int spielerID, int trainingSpielerID)
        {
            _ = bestleistungRepository.Speichern(new Bestleistung
            {
                Art = art,
                GeworfenAm = DateTime.Now,
                Herkunft = herkunft,
                SpielerID = spielerID,
                TrainingSpielerID = trainingSpielerID,
                Value = value
            });
        }

        public void NeueBestleistung(BestleistungHerkunft herkunft, BestleistungArt art, int spielerID, int trainingSpielerID)
        {
            _ = bestleistungRepository.Speichern(new Bestleistung
            {
                Art = art,
                GeworfenAm = DateTime.Now,
                Herkunft = herkunft,
                SpielerID = spielerID,
                TrainingSpielerID = trainingSpielerID
            });
        }

        public void Entfernen(int iD) => bestleistungRepository.Entfernen(iD);

        public IList<Bestleistung> LadeAlleFuerTrainingSpieler(int trainingSpielerID) => bestleistungRepository.LadeAlleByTrainingSpielerID(trainingSpielerID);

        internal IList<Bestleistung> LadeByAuswertungArt(BestleistungAuswertungArt bestleistungAuswertungArt)
        {
            switch (bestleistungAuswertungArt)
            {
                case BestleistungAuswertungArt.HundertAchtzig:
                    return bestleistungRepository.LadeAlleHundertAchtzig();
                case BestleistungAuswertungArt.Highfinish:
                    return bestleistungRepository.LadeAlleByArt(BestleistungArt.highfinish);
                case BestleistungAuswertungArt.Highscore:
                    return bestleistungRepository.LadeAlleByArt(BestleistungArt.highscore);
                case BestleistungAuswertungArt.ShortLeg:
                    return bestleistungRepository.LadeAlleByArt(BestleistungArt.shortLeg);
                case BestleistungAuswertungArt.BullFinish:
                    return bestleistungRepository.LadeAlleByArt(BestleistungArt.bullfinish);
                default:
                    return new List<Bestleistung>();
            }
            
        }

        internal IList<Bestleistung> LadeByAuswertungArtUndJahr(BestleistungAuswertungArt bestleistungAuswertungArt, int jahr)
        {
            switch (bestleistungAuswertungArt)
            {
                case BestleistungAuswertungArt.HundertAchtzig:
                    return bestleistungRepository.LadeAlleHundertAchtzigImJahr(jahr);
                case BestleistungAuswertungArt.Highfinish:
                    return bestleistungRepository.LadeAlleByArtImJahr(BestleistungArt.highfinish, jahr);
                case BestleistungAuswertungArt.Highscore:
                    return bestleistungRepository.LadeAlleByArtImJahr(BestleistungArt.highscore, jahr);
                case BestleistungAuswertungArt.ShortLeg:
                    return bestleistungRepository.LadeAlleByArtImJahr(BestleistungArt.shortLeg, jahr);
                case BestleistungAuswertungArt.BullFinish:
                    return bestleistungRepository.LadeAlleByArtImJahr(BestleistungArt.bullfinish, jahr);
                default:
                    return new List<Bestleistung>();
            }
        }
    }
}
