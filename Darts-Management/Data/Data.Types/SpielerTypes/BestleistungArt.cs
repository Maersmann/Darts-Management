using Darts.Data.Types.Converter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Data.Types.SpielerTypes
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BestleistungArt
    {
        [Description("Highscore")]
        highscore,
        [Description("Highfinish")]
        highfinish,
        [Description("Short Leg")]
        shortLeg,
        [Description("Bullfinish")]
        bullfinish
    }
}
