using Darts.Logic.Messages.BaseMessages;
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

namespace Vereinsverwaltung.UI.Desktop
{
    /// <summary>
    /// Interaktionslogik für StartingProgrammView.xaml
    /// </summary>
    public partial class StartingProgrammView : Window
    {
        public StartingProgrammView()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseViewMessage>(this, "StartingProgramm", m => ReceivCloseViewMessage());
        }

        private void ReceivCloseViewMessage()
        {
            GetWindow(this).Close();
        }
    }
}
