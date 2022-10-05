using Darts.Data.Types.BaseTypes;
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
using UI.Desktop.BaseViews;

namespace UI.Desktop.Spieler
{
    /// <summary>
    /// Interaktionslogik für SpielerStammdatenView.xaml
    /// </summary>
    public partial class SpielerStammdatenView : StammdatenView
    {
        public SpielerStammdatenView()
        {
            InitializeComponent();
            RegisterStammdatenGespeichertMessage(StammdatenTypes.spieler);
        }
    }
}
