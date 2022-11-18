using Darts.Data.Types.AuswertungTypes;
using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.AuswertungCore;
using Darts.Logic.Core.Validierung;
using Darts.Logic.Models.AuswertungModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI.AuswertungenViewModels
{
    public class AuswertungBestleistungenJahreslisteViewModel : ViewModelUebersicht<AuswertungBestleistungenAllTimeModel, StammdatenTypes>
    {
        private int gesamtAnzahl = 0;
        private int jahr = DateTime.Now.Year;
        private BestleistungAuswertungArt bestleistungAuswertungArt = BestleistungAuswertungArt.HundertAchtzig;
        public AuswertungBestleistungenJahreslisteViewModel()
        {
            Title = "Jahresliste Bestwerte";
            ErmittelnCommand = new RelayCommand(() => ExcecuteErmittelnCommand());
        }

        protected override bool LoadDataBeimCreateAusfuehren => false;


        private void ExcecuteErmittelnCommand()
        {
            ItemList.Clear();
            ItemList = new AuswertungBestleistungService().ErmittleBestliste(BestlisteAuswertungArt.Jahresliste, bestleistungAuswertungArt, jahr);
            BerechneGesamtAnzahl();
        }

        #region Binding
        public int GesamtAnzahl => gesamtAnzahl;
        public int? Jahr
        {
            get => jahr;
            set
            {
                ValidatZahl(value, nameof(Jahr));
                RaisePropertyChanged();
                jahr = value.GetValueOrDefault(0);
            }
        }
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

        #region Validate
        private bool ValidatZahl(int? zahl, string fieldname)
        {
            var Validierung = new BaseValidierung();

            bool isValid = Validierung.ValidateAnzahl(zahl, out ICollection<string> validationErrors);

            AddValidateInfo(isValid, fieldname, validationErrors);
            return isValid;
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
