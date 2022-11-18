using Darts.Data.Infrastructure.Base;
using Darts.Data.Model.TrainingEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darts.Data.Infrastructure.TrainingRepositorys
{
    public class TrainingSpielerRepository : BaseRepository<TrainingSpieler>
    {
        public bool IstSpielerImTrainingVorhanden(int spielerID)
        {
            return context.TrainingSpielers.FirstOrDefault(t => t.SpielerID.Equals(spielerID)) != null;
        }
    }
}
