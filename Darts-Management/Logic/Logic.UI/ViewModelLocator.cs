/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:UI.Desktop"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using Darts.Logic.UI.AuswahlViewModels;
using Darts.Logic.UI.AuswertungenViewModels;
using Darts.Logic.UI.KonfigurationViewModels;
using Darts.Logic.UI.OptionenViewModels;
using Darts.Logic.UI.SpielerViewModels;
using Darts.Logic.UI.TrainingViewModels;
using Darts.Logic.UI.UtilsViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;

namespace Darts.Logic.UI
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models                
            }
            else
            {
                // Create run time view services and models                
            }
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public BestaetigungViewModel Bestaetigung => new BestaetigungViewModel();
        public LoginViewModel Login => new LoginViewModel();
        public StartingProgrammViewModel StartingProgramm => new StartingProgrammViewModel();
        public KonfigruationViewModel KonfigruationViewModel => new KonfigruationViewModel();
        public DBSettingsViewModel DBSettings => new DBSettingsViewModel();
        public SpielerUebersichtViewModel SpielerUebersicht => new SpielerUebersichtViewModel();
        public SpielerStammdatenViewModel SpielerStammdaten => new SpielerStammdatenViewModel();
        public AktuellesTrainingViewModel AktuellesTraining => new AktuellesTrainingViewModel();
        public SpielerAuswahlViewModel SpielerAuswahl => new SpielerAuswahlViewModel();
        public AktuellesTrainingSpielerBestleistungViewModel AktuellesTrainingSpielerBesteWerte => new AktuellesTrainingSpielerBestleistungViewModel();
        public BestleistungEintragenViewModel BestleistungEintragen => new BestleistungEintragenViewModel();
        public TrainingUebersichtViewModel TrainingUebersicht => new TrainingUebersichtViewModel();
        public InfoViewModel Info => new InfoViewModel();
        public AuswertungBestleistungenAllTimeViewModel AuswertungBestleistungenAllTime => new AuswertungBestleistungenAllTimeViewModel();
        public AuswertungBestleistungenJahreslisteViewModel AuswertungBestleistungenJahresliste => new AuswertungBestleistungenJahreslisteViewModel();
        public AuswertungBestleistungenMonatslisteViewModel auswertungBestleistungenMonatsliste => new AuswertungBestleistungenMonatslisteViewModel();


        public static void Cleanup()
        {

        }
    }
}