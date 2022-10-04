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
using Darts.Logic.UI.KonfigurationViewModels;
using Darts.Logic.UI.OptionenViewModels;
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


        public static void Cleanup()
        {

        }
    }
}