using Darts.Data.Model.Base;
using Darts.Data.Model.TrainingEntitys;
using Darts.Data.Types.SpielerTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Data.Model.SpielerEntitys
{
    [Table("Bestleistung")]
    public class Bestleistung : DAO
    {
        public BestleistungArt Art { get; set; }
        public BestleistungHerkunft Herkunft { get; set; }
        public int? Value { get; set; }
        public int? TrainingSpielerID { get; set; }
        public DateTime? GeworfenAm { get; set; }
        public int SpielerID { get; set; }

        public virtual TrainingSpieler TrainingSpieler { get; set; }
        public virtual Spieler Spieler { get; set; }
    }
}
