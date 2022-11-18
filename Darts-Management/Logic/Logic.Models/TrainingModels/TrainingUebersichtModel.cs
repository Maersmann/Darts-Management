using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Models.TrainingModels
{
    public class TrainingUebersichtModel
    {
        public int ID { get; set; }
        public DateTime Tag { get; set; }
        public bool Aktiv { get; set; }
        public int AnzahlSpieler { get; set; }
        public int AnzahlHighscore { get;  set; }
        public int AnzahlHighfinish { get; set; }
        public int AnzahlShortLeg { get; set; }
        public int AnzahlBullFinish { get; set; }

        public string Wochentag => Tag.ToString("dddd", new CultureInfo("de-DE"));
    }
}
