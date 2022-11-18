using Darts.Data.Types.SpielerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Models.TrainingModels
{
    public class TrainingBestleistungenUebersichtModel
    {
        public string Name { get; set; }
        public BestleistungArt BestleistungArt { get; set;}
        public DateTime GeworfenAm { get; set; }
        public string Value { get; set; }
    }
}
