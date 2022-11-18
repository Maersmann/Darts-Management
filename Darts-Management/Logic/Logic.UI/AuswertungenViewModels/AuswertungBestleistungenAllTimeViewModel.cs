using Darts.Data.Types.AuswertungTypes;
using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.AuswertungCore;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Models.AuswertungModels;
using Darts.Logic.Models.SpielerModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI.AuswertungenViewModels
{
    public class AuswertungBestleistungenAllTimeViewModel : ViewModelUebersicht<AuswertungBestleistungenAllTimeModel, StammdatenTypes>
    {
        public int gesamtAnzahl = 0;
        private BestleistungAuswertungArt bestleistungAuswertungArt = BestleistungAuswertungArt.HundertAchtzig;

        public AuswertungBestleistungenAllTimeViewModel()
        {
            Title = "All-Time Bestwerte";
            ErmittelnCommand = new RelayCommand(() => ExcecuteErmittelnCommand());
        }

        protected override bool LoadDataBeimCreateAusfuehren => false;

        private void ExcecuteErmittelnCommand()
        {
            ItemList.Clear();
            ItemList = new AuswertungBestleistungService().ErmittleBestliste(BestlisteAuswertungArt.AllTime, bestleistungAuswertungArt);
            BerechneGesamtAnzahl();
        }

        #region Bindings
        public int GesamtAnzahl => gesamtAnzahl;
        public ICommand ErmittelnCommand { get; set; }
        public IEnumerable<BestleistungAuswertungArt> BestleistungAuswertungArten => Enum.GetValues(typeof(BestleistungAuswertungArt)).Cast<BestleistungAuswertungArt>();
        public BestleistungAuswertungArt BestleistungAuswertungArt
        {
            get => bestleistungAuswertungArt;
            set
            {
                bestleistungAuswertungArt = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        private void BerechneGesamtAnzahl()
        {
            gesamtAnzahl = 0;
            ItemList.ToList().ForEach(x => gesamtAnzahl += x.Anzahl);
            RaisePropertyChanged(nameof(GesamtAnzahl));
        }
    }
}
