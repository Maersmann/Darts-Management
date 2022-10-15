using Darts.Logic.Messages.SpielerMessages;
using Darts.Logic.UI.SpielerViewModels;
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
using System.Windows.Shapes;
using UI.Desktop.Spieler;

namespace UI.Desktop.Training
{
    /// <summary>
    /// Interaktionslogik für AktuellesTrainingSpielerBestleistungView.xaml
    /// </summary>
    public partial class AktuellesTrainingSpielerBestleistungView : Window
    {
        public AktuellesTrainingSpielerBestleistungView()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenBestwerteEintragenMessage>(this, "AktuellesTrainingSpielerBestleistung", m => ReceiveOpenBesteWerteMessage(m));
        }

        private void ReceiveOpenBesteWerteMessage(OpenBestwerteEintragenMessage m)
        {
            BestleistungEintragenView view = new BestleistungEintragenView
            {
                Owner = Application.Current.MainWindow
            };

            if (view.DataContext is BestleistungEintragenViewModel model)
            {
                model.SetzeDaten(m.Art, m.Herkunft, m.SpielerID, m.TrainingSpielerID);
                view.ShowDialog();
                m.Callback();
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<OpenBestwerteEintragenMessage>(this);
        }
    }
}
