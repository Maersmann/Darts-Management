using Darts.Data.Types.BaseTypes;
using Darts.Logic.Messages.BaseMessages;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        }
    }
}
