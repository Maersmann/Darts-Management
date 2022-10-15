using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Models.AuswahlModels;
using Darts.Logic.UI.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Darts.Logic.UI.AuswahlViewModels
{
    public class SpielerAuswahlViewModel : ViewModelAuswahl<SpielerAuswahlModel, StammdatenTypes>
    {
        private readonly SpielerService spielerService;

        public SpielerAuswahlViewModel()
        {
            spielerService = new SpielerService();
            Title = "Auswahl Spieler";
        }

        public int? ID()
        {
            return SelectedItem == null ? null : (int?)SelectedItem.ID;
        }
        public void SetzeVorhandeneIDs(IList<int> iDs) => LoadData(iDs);

        protected override void LoadData()
        {
            ItemList = spielerService.LadeFuerAuswahl(FilterText);
        }

        protected override void LoadData(IList<int> vorhandeneIDs)
        {
            base.LoadData(vorhandeneIDs);
            ItemList = spielerService.LadeFuerAuswahl(FilterText, vorhandeneIDs);
        }

        protected override StammdatenTypes GetStammdatenType() { return StammdatenTypes.spieler; }
        protected override bool LoadDataBeimCreateAusfuehren => false;
        protected override void ExecuteCloseWindowCommand(Window window)
        {
            AuswahlGetaetigt = true;
            base.ExecuteCloseWindowCommand(window);
        }

    }
}
