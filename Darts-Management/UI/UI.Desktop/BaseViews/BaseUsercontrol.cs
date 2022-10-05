using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.UI.UtilsViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Vereinsverwaltung.UI.Desktop.Utils;

namespace UI.Desktop.BaseViews
{
    public class BaseUsercontrol : UserControl
    {

        public BaseUsercontrol()
        {
            Unloaded += Window_Unloaded;
        }

        public void RegisterMessages(string token)
        {
            Messenger.Default.Register<OpenBestaetigungViewMessage>(this, token, m => ReceiveOpenBestaetigungViewMessage(m));
        }

        private void ReceiveOpenBestaetigungViewMessage(OpenBestaetigungViewMessage m)
        {
            var Bestaetigung = new BestaetigungView();
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

        protected virtual void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Unregister<OpenBestaetigungViewMessage>(this);
        }
    }
}
