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
            ItemList.Clear();
            var Spieler = spielerService.LadeAlle(FilterText);
            Spieler.ToList().ForEach(spieler =>
            {
                ItemList.Add(new SpielerAuswahlModel
                {
                    ID = spieler.ID,
                    Name = spieler.Name,
                    Vorname = spieler.Vorname
                });
            });
            if (ItemList.Count > 0)
            {
                SelectedItem = ItemList.First();
            }
        }

        protected override void LoadData(IList<int> vorhandeneIDs)
        {
            ItemList.Clear();
            base.LoadData(vorhandeneIDs);
            var Spieler = spielerService.LadeAlle(FilterText, vorhandeneIDs);
            Spieler.ToList().ForEach(spieler =>
            {
                ItemList.Add(new SpielerAuswahlModel
                {
                    ID = spieler.ID,
                    Name = spieler.Name,
                    Vorname = spieler.Vorname
                });
            });
            if (ItemList.Count > 0)
            {
                SelectedItem = ItemList.First();
            }
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
