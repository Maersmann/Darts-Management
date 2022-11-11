using Darts.Data.Types.Converter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Data.Types.AuswertungTypes
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BestleistungAuswertungArt
    {
        [Description("180")]
        HundertAchtzig,
        [Description("Highfinish")]
        Highfinish,
        [Description("Highscore")]
        Highscore,
        [Description("Short Leg")]
        ShortLeg,
        [Description("Bullfinish")]
        BullFinish
    }
}
