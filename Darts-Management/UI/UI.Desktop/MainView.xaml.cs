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
                case ViewType.AuswertungBestleistungAllTimeHundertAchtzig:

                        var view = new AuswertungBestleistungenAllTimeView();
                        if (view.DataContext is AuswertungBestleistungenAllTimeViewModel model)
                        {
                            model.LoadData(BestleistungAuswertungArt.HundertAchtzig);
                        }
                        _ = Container.NavigationService.Navigate(view);

                    break;
                case ViewType.AuswertungBestleistungAllTimeHighscore:

                        var viewHighScore = new AuswertungBestleistungenAllTimeView();
                        if (viewHighScore.DataContext is AuswertungBestleistungenAllTimeViewModel viewHighScoreModel)
                        {
                        viewHighScoreModel.LoadData(BestleistungAuswertungArt.Highscore);
                        }
                        _ = Container.NavigationService.Navigate(viewHighScore);

                    break;
                case ViewType.AuswertungBestleistungAllTimeHighfinish:

                        var viewHighFinish = new AuswertungBestleistungenAllTimeView();
                        if (viewHighFinish.DataContext is AuswertungBestleistungenAllTimeViewModel viewHighFinishModel)
                        {
                        viewHighFinishModel.LoadData(BestleistungAuswertungArt.Highfinish);
                        }
                        _ = Container.NavigationService.Navigate(viewHighFinish);
 
                    break;
                case ViewType.AuswertungBestleistungAllTimeBullfinish:

                        var viewBullFinish = new AuswertungBestleistungenAllTimeView();
                        if (viewBullFinish.DataContext is AuswertungBestleistungenAllTimeViewModel viewBullFinishModel)
                        {
                            viewBullFinishModel.LoadData(BestleistungAuswertungArt.BullFinish);
                        }
                        _ = Container.NavigationService.Navigate(viewBullFinish);

                    break;
                case ViewType.AuswertungBestleistungAllTimeShortLeg:

                        var viewShortLeg = new AuswertungBestleistungenAllTimeView();
                        if (viewShortLeg.DataContext is AuswertungBestleistungenAllTimeViewModel viewShortLegModel)
                        {
                            viewShortLegModel.LoadData(BestleistungAuswertungArt.ShortLeg);
                        }
                        _ = Container.NavigationService.Navigate(viewShortLeg);

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
