using Darts.Data.Infrastructure.Base;
using Darts.Data.Model.SpielerEntitys;
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
    }
}
