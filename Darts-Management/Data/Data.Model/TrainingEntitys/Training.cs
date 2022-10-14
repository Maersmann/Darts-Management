using Darts.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Data.Model.TrainingEntitys
{
    [Table("Training")]
    public class Training : DAO
    {
        public DateTime? Start { get; set; }
        public DateTime? Ende { get; set; }
        public bool Aktiv { get; set;  }
    }
}
