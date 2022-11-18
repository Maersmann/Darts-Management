using Darts.Logic.Messages.SpielerMessages;
using Darts.Logic.Messages.TrainingMessages;
using Darts.Logic.UI.SpielerViewModels;
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
using UI.Desktop.Training;

namespace UI.Desktop.Spieler
{
    /// <summary>
    /// Interaktionslogik für SpielerUebersichtView.xaml
    /// </summary>
    public partial class SpielerUebersichtView : UserControl
    {
        public SpielerUebersichtView()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenBestleistungenVomSpielerMessage>(this, "SpielerUebersicht", m => ReceiveOpenBestleistungenVomSpielerMessage(m));
        }

        private void ReceiveOpenBestleistungenVomSpielerMessage(OpenBestleistungenVomSpielerMessage m)
        {
            SpielerBestleistungenUebersichtView view = new SpielerBestleistungenUebersichtView
            {
                Owner = Application.Current.MainWindow
            };

            if (view.DataContext is SpielerBestleistungenUebersichtViewModel model)
            {
                model.LoadData(m.ID);
                view.ShowDialog();
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<OpenBestleistungenVomSpielerMessage>(this);
        }
    }
}
