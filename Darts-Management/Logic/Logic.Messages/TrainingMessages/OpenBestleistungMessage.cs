using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Messages.TrainingMessages
{
    public class OpenBestleistungMessage
    {
        public int SpielerID { get; set; }
        public int SpielerTrainingID { get; set; }
    }
}
