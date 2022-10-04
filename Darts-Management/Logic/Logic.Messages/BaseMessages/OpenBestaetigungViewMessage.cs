using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Messages.BaseMessages
{
    public class OpenBestaetigungViewMessage
    {
        public Action Command { get; set; }
        public string Beschreibung { get; set; }
    }
}
