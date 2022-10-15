using Darts.Data.Types.SpielerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Models.TrainingModels
{
    public class AktuellesTrainingSpielerBestleistungModel
    {
        public int ID { get; set; }
        public BestleistungArt BestleistungArt { get; set; }
        public DateTime GeworfenAm { get; set; }
        public string Value { get; set; }
    }
}
