using Darts.Data.Model.Base;
using Darts.Data.Model.SpielerEntitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Data.Model.TrainingEntitys
{
    [Table("TrainingSpieler")]
    public class TrainingSpieler : DAO
    {
        public int SpielerID { get; set; }
        public int TrainingID { get; set; }
        public DateTime? AngemeldetAm { get; set; }

        public virtual Spieler Spieler { get; set; }
        public virtual Training Training { get; set; }
    }
}
