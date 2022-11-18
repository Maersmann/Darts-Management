using Darts.Data.Types.BaseTypes;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.UI.InterfaceViewModels;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using UI.Desktop.Spieler;
using Vereinsverwaltung.UI.Desktop;
using Vereinsverwaltung.UI.Desktop.Konfigruation;
using UI.Desktop.BaseViews;
using UI.Desktop.Training;
using Darts.Logic.UI.TrainingViewModels;
using System.Web.UI.WebControls;
using UI.Desktop.Auswertung;
using Darts.Logic.UI.AuswertungenViewModels;
using Darts.Data.Types.AuswertungTypes;

namespace Darts.UI.Desktop
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainView
    {


        public MainView()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenViewMessage>(this, m => ReceiveOpenViewMessage(m));
            Messenger.Default.Register<ExceptionMessage>(this, m => ReceiveExceptionMessage(m));
            Messenger.Default.Register<InformationMessage>(this, m => ReceiveInformationMessage(m));
            Messenger.Default.Register<BaseStammdatenMessage<StammdatenTypes>>(this, m => ReceiceOpenStammdatenMessage(m));
            Messenger.Default.Register<OpenStartingViewMessage>(this, m => ReceiceOpenStartingViewMessage());
            Messenger.Default.Register<OpenLoginViewMessage>(this, m => ReceiceOpenLoginViewMessage());
            Messenger.Default.Register<OpenKonfigurationViewMessage>(this, m => ReceiceOpenKonfigurationViewMessage());
            Messenger.Default.Register<CloseApplicationMessage>(this, m => ReceiceCloseApplicationMessage());
        }

        private void ReceiveInformationMessage(InformationMessage m)
        {
            _ = MessageBox.Show(m.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ReceiveExceptionMessage(ExceptionMessage m)
        {
            _ = MessageBox.Show(m.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ReceiveOpenViewMessage(OpenViewMessage m)
        {
            Naviagtion(m.ViewType);
        }

        public void Naviagtion(ViewType inType)
        {
            switch (inType)
            {

                case ViewType.SpielerUebersicht:
                    if (Container.Content == null || !Container.Content.GetType().Name.Equals(nameof(SpielerUebersichtView)))
                    {
                        _ = Container.NavigationService.Navigate(new SpielerUebersichtView());
                    }
                    break;
                case ViewType.AktuellesTraining:
                    if (Container.Content == null || !Container.Content.GetType().Name.Equals(nameof(AktuellesTrainingView)))
                    {
                        var viewTraining = new AktuellesTrainingView();
                            _ = Container.NavigationService.Navigate(viewTraining);
                        if (viewTraining.DataContext is AktuellesTrainingViewModel trainingModel)
                        {
                            trainingModel.CheckAktuellesTraining();
                        }
                    }
                    break;
                case ViewType.TrainingUebersicht:
                    if (Container.Content == null || !Container.Content.GetType().Name.Equals(nameof(TrainingUebersichtView)))
                    {
                        _ = Container.NavigationService.Navigate(new TrainingUebersichtView());
                    }
                    break;
                case ViewType.AuswertungBestleistungAllTime:
                    if (Container.Content == null || !Container.Content.GetType().Name.Equals(nameof(AuswertungBestleistungenAllTimeView)))
                    {
                        _ = Container.NavigationService.Navigate(new AuswertungBestleistungenAllTimeView());
                    }
                    break;

                case ViewType.AuswertungBestleistungJahresliste:
                    if (Container.Content == null || !Container.Content.GetType().Name.Equals(nameof(AuswertungBestleistungenJahreslisteView)))
                    {
                        _ = Container.NavigationService.Navigate(new AuswertungBestleistungenJahreslisteView());
                    }
                    break;
                case ViewType.AuswertungBestleistungMonatsliste:
                    if (Container.Content == null || !Container.Content.GetType().Name.Equals(nameof(AuswertungBestleistungenMonatslisteView)))
                    {
                        _ = Container.NavigationService.Navigate(new AuswertungBestleistungenMonatslisteView());
                    }
                    break;
                default:
                    break;               
            }
        }


        private void ReceiceOpenStammdatenMessage(BaseStammdatenMessage<StammdatenTypes> m)
        {
            StammdatenView view = null;
            switch (m.Stammdaten)
            {
                case StammdatenTypes.spieler:
                    view = new SpielerStammdatenView();
                    break;
                default:
                    break;
            }

            if (view.DataContext is IViewModelStammdaten model)
            {
                if (m.State == State.Bearbeiten)
                {
                    model.ZeigeStammdatenAn(m.ID.Value);
                }
                view.Owner = this;
                _ = view.ShowDialog();
                m.Callback?.Invoke(model.NeuerEintragAngelegt(), model.Filter());
            }

        }

        private void ReceiceOpenStartingViewMessage()
        {
            _ = new StartingProgrammView().ShowDialog();
        }

        private void ReceiceOpenLoginViewMessage()
        {
            _ = new Vereinsverwaltung.UI.Desktop.LoginView()
            {
                Owner = Application.Current.MainWindow
            }.ShowDialog();
        }

        private void ReceiceOpenKonfigurationViewMessage()
        {
            new KonfigurationView().ShowDialog();
        }

        private void ReceiceCloseApplicationMessage()
        {
            Application.Current.Shutdown();
        }

    }

}
