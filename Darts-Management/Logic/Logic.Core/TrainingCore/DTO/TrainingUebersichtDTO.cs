using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Core.TrainingCore.DTO
{
    public class TrainingUebersichtDTO
    {
        public int ID { get; set; }
        public DateTime Tag { get; set; }
        public bool Aktiv { get; set; }
        public int AnzahlSpieler { get; set; }
        public int AnzahlHighscore { get; set; }
        public int AnzahlHighfinish { get; set; }
        public int AnzahlShortLeg { get; set; }
        public int AnzahlBullFinish { get; set; }
    }
}
