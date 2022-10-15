using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Models.TrainingModels
{
    public class AktuellesTrainingModel
    {
        public int TrainingID { get; set; }
        public ObservableCollection<AktuellesTrainingSpielerModel> Spieler { get; set; }

        public AktuellesTrainingModel()
        {
            Spieler = new ObservableCollection<AktuellesTrainingSpielerModel>();
        }
    }

    public class AktuellesTrainingSpielerModel
    {
        public string Vorname { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public int SpielerTrainingID { get; set; }
    }
}
