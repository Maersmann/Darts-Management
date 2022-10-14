using Darts.Data.Infrastructure.Base;
using Darts.Data.Model.TrainingEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darts.Data.Infrastructure.TrainingRepositorys
{
    public class TrainingRepository : BaseRepository<Training>
    {
        public bool IstEinTrainingAktiv()
        {
            return context.Trainings.FirstOrDefault(t => t.Aktiv) != null;
        }
    }
}
