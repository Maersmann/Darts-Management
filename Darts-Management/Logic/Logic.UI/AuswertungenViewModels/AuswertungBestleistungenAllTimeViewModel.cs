using Darts.Data.Types.AuswertungTypes;
using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.AuswertungCore;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Models.AuswertungModels;
using Darts.Logic.Models.SpielerModels;
using Darts.Logic.UI.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.AuswertungenViewModels
{
    public class AuswertungBestleistungenAllTimeViewModel : ViewModelUebersicht<AuswertungBestleistungenAllTimeModel, StammdatenTypes>
    {
        public AuswertungBestleistungenAllTimeViewModel()
        {
            Title = "All-Time Bestwerte";
        }

        protected override bool LoadDataBeimCreateAusfuehren => false;

        public void LoadData(BestleistungAuswertungArt bestleistungAuswertungArt)
        {
            ItemList.Clear();
            ItemList = new AuswertungBestleistungService().ErmittleAllTime(bestleistungAuswertungArt);
        }
    }
}
