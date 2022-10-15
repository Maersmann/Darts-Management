using Darts.Data.Types.SpielerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Messages.SpielerMessages
{
    public class OpenBestwerteEintragenMessage
    {
        public Action Callback { get; set; }
        public BestleistungArt Art { get; set; }
        public BestleistungHerkunft Herkunft { get; set; }
        public int SpielerID { get; set; }
        public int TrainingSpielerID { get; set; }
    }
}
