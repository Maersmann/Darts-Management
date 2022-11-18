using Darts.Logic.Messages.AuswahlMessages;
using Darts.Logic.Messages.TrainingMessages;
using Darts.Logic.UI.AuswahlViewModels;
using Darts.Logic.UI.TrainingViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Desktop.Auswahl;
using UI.Desktop.BaseViews;

namespace UI.Desktop.Training
{
    /// <summary>
    /// Interaktionslogik für AktuellesTrainingView.xaml
    /// </summary>
    public partial class AktuellesTrainingView : BaseUsercontrol
    {
        public AktuellesTrainingView()
        {
            InitializeComponent();
            RegisterMessages("AktuellesTraining");
            Messenger.Default.Register<OpenSpielerAuswahlMessage>(this, "AktuellesTraining", m => ReceiveOpenSpielerAuswahlMessage(m));
            Messenger.Default.Register<OpenBestleistungMessage>(this, "AktuellesTraining", m => ReceiveOpenBesteWerteMessage(m));
            Messenger.Default.Register<OpenBestleistungenVomTrainingMessage>(this, "AktuellesTraining", m => ReceiveOpenBestleistungenVomTrainingMessage(m));
        }

        private void ReceiveOpenBestleistungenVomTrainingMessage(OpenBestleistungenVomTrainingMessage m)
        {
            TrainingBestleistungenUebersichtView view = new TrainingBestleistungenUebersichtView
            {
                Owner = Application.Current.MainWindow
            };

            if (view.DataContext is TrainingBestleistungenUebersichtViewModel model)
            {
                model.LoadData(m.ID);
                view.ShowDialog();
            }
        }

        private void ReceiveOpenBesteWerteMessage(OpenBestleistungMessage m)
        {
            AktuellesTrainingSpielerBestleistungView view = new AktuellesTrainingSpielerBestleistungView
            {
                Owner = Application.Current.MainWindow
            };

            if (view.DataContext is AktuellesTrainingSpielerBestleistungViewModel model)
            {
                model.LadeBesteWerteFuerSpieler(m.SpielerID, m.SpielerTrainingID);
                view.ShowDialog();
            }
        }

        private void ReceiveOpenSpielerAuswahlMessage(OpenSpielerAuswahlMessage m)
        {
            SpielerAuswahlView view = new SpielerAuswahlView
            {
                Owner = Application.Current.MainWindow
            };
           
            if (view.DataContext is SpielerAuswahlViewModel model)
            {
                model.SetzeVorhandeneIDs(m.VorhandeneIDs);
                view.ShowDialog();
                if (model.AuswahlGetaetigt && model.ID().HasValue)
                {
                    m.Callback(true, model.ID().Value);
                }
                else
                {
                    m.Callback(false, 0);
                }
            }
        }

        protected override void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            base.Window_Unloaded(sender, e);
            Messenger.Default.Unregister<OpenSpielerAuswahlMessage>(this);
            Messenger.Default.Unregister<OpenBestleistungMessage>(this);
            Messenger.Default.Unregister<OpenBestleistungenVomTrainingMessage>(this);
        }
    }
}
