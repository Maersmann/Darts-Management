using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Messages.AuswahlMessages
{
    public class OpenSpielerAuswahlMessage
    {
        public Action<bool, int> Callback { get; private set; }
        public IList<int> VorhandeneIDs { get; set; }

        public OpenSpielerAuswahlMessage(Action<bool, int> callback)
        {
            Callback = callback;

            VorhandeneIDs = new List<int>();
        }
    }
}
