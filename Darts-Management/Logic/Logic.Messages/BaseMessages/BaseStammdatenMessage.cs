using Darts.Data.Types.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Messages.BaseMessages
{
    public class BaseStammdatenMessage<T>
    {
        public Action<bool, string> Callback { get; set; }
        public T Stammdaten { get; set; }
        public State State { get; set; }
        public int? ID { get; set; }

        public BaseStammdatenMessage()
        {
            Callback = null;
        }

    }
}
