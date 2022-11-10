using Darts.Data.Infrastructure.Base;
using Darts.Data.Model.SpielerEntitys;
using Darts.Data.Types.SpielerTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darts.Data.Infrastructure.SpielerRepositorys
{
    public class BestleistungRepository : BaseRepository<Bestleistung>
    {
        public IList<Bestleistung> LadeAlleByTrainingSpielerID(int trainingSpielerID)
        {
            return context.Bestleistungen.Where(w => w.TrainingSpielerID.Equals(trainingSpielerID)).ToList();
        }

        public bool HatTrainingSpielerEinEintrag(int trainingSpielerID)
        {
            return context.Bestleistungen.FirstOrDefault(t => t.TrainingSpielerID.Equals(trainingSpielerID)) != null;
        }

        public IList<Bestleistung> LadeAlleByTrainingID(int trainingID)
        {
            return context.Bestleistungen.Where(t => t.TrainingSpieler.TrainingID.Equals(trainingID)).ToList();
        }

        public IList<Bestleistung> LadeAlleHundertAchtzig()
        {
            return context.Bestleistungen.Where(w => w.Value.Equals(180) && w.Art.Equals(BestleistungArt.highscore)).Include( i => i.Spieler).ToList();
        }

        public IList<Bestleistung> LadeAlleByArt(BestleistungArt art)
        {
            return context.Bestleistungen.Where(w => w.Art.Equals(art)).Include(i => i.Spieler).ToList();
        }
    }
}
