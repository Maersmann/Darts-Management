using Darts.Logic.Messages.AuswahlMessages;
using Darts.Logic.Messages.TrainingMessages;
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

namespace UI.Desktop.Training
{
    /// <summary>
    /// Interaktionslogik für TrainingUebersichtView.xaml
    /// </summary>
    public partial class TrainingUebersichtView : UserControl
    {
        public TrainingUebersichtView()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenBestleistungenVomTrainingMessage>(this, "TrainingUebersicht", m => ReceiveOpenBestleistungenVomTrainingMessage(m));
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

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<OpenBestleistungenVomTrainingMessage>(this);
        }
    }
}
