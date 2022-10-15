using Darts.Data.Infrastructure.SpielerRepositorys;
using Darts.Data.Model.SpielerEntitys;
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
    }
}
