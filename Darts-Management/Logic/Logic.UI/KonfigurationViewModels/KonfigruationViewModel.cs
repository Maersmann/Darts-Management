using Darts.Logic.Core.OptionenCore;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Darts.Logic.UI.KonfigurationViewModels
{
    public class KonfigruationViewModel : ViewModelBasis
    {
        public KonfigruationViewModel()
        {
            Title = "Konfiguration der Software";
        }

        protected override void ExecuteCloseWindowCommand(Window window)
        {
            base.ExecuteCloseWindowCommand(window);
            if (!new BackendLogic().IstINIVorhanden())
            {
                Messenger.Default.Send(new CloseApplicationMessage());
            }
        }


    }
}
