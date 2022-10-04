using Darts.Data.Model.Base;
using Darts.Data.Types.KonvertierungTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Data.Model.KonvertierungEntitys
{
    [Table("Konvertierung")]
    public class Konvertierung : DAO
    {
        [EnumDataType(typeof(KonvertierungTypes))]
        public KonvertierungTypes Typ { get; set; }

    }
}
