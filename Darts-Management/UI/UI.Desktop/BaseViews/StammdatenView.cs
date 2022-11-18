using Darts.Data.Types.BaseTypes;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.UI.UtilsViewModels;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vereinsverwaltung.UI.Desktop.Utils;

namespace UI.Desktop.BaseViews
{
    public class StammdatenView : Window
    {
        public StammdatenView()
        {
            Unloaded += Window_Unloaded;
        }

        public void RegisterStammdatenGespeichertMessage(StammdatenTypes types)
        {
            Messenger.Default.Register<StammdatenGespeichertMessage>(this, types, m => ReceiveStmmdatenGespeichertMessage(m));
            Messenger.Default.Register<OpenBestaetigungViewMessage>(this, types, m => ReceiveOpenBestaetigungViewMessage(m));
        }

        private void ReceiveOpenBestaetigungViewMessage(OpenBestaetigungViewMessage m)
        {
            var Bestaetigung = new BestaetigungView
            {
                Owner = Application.Current.MainWindow
            };

            if (Bestaetigung.DataContext is BestaetigungViewModel model)
            {
                model.Beschreibung = m.Beschreibung;
                Bestaetigung.ShowDialog();
                if (model.Bestaetigt)
                {
                    m.Command();
                }
            }

        }

        private void ReceiveStmmdatenGespeichertMessage(StammdatenGespeichertMessage m)
        {
            if (m.Erfolgreich)
            {
                MessageBox.Show(m.Message);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show(m.Message);
            }
        }

        internal void MessageWithToken(string token)
        {
            Messenger.Default.Register<StammdatenGespeichertMessage>(this, token, m => ReceiveStmmdatenGespeichertMessage(m));
        }

        public virtual void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<StammdatenGespeichertMessage>(this);
            Messenger.Default.Unregister<OpenBestaetigungViewMessage>(this);
        }
    }
}
