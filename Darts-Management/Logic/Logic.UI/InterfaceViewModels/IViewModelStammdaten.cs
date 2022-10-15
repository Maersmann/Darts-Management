using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.InterfaceViewModels
{
    public interface IViewModelStammdaten
    {
        void ZeigeStammdatenAn(int id);
        bool NeuerEintragAngelegt();
        string Filter();
    }
}
