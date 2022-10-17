using Darts.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Data.Model.SpielerEntitys
{
    [Table("Spieler")]
    public class Spieler : DAO
    {
        public string Name { get; set; }
        public string Vorname { get; set; }

        public IList<Bestleistung> Bestleistungen { get; set; }
    }
}
