using Darts.Data.Infrastructure.TrainingRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Darts.Data.Model.TrainingEntitys;

namespace Darts.Logic.Core.TrainingCore
{
    public class TrainingService
    {
        private readonly TrainingRepository repo;

        public TrainingService()
        {
            repo = new TrainingRepository();
        }

        public bool IstEinTrainingAktuellAktiv => repo.IstEinTrainingAktiv();

        public void NeuesTrainingErstellen()
        {
            var Training = new Training { Aktiv = true, Start = DateTime.Now };
            repo.Speichern(Training);
        }
    }
}