using Darts.Logic.Models.OptionenModels;
using Darts.Logic.UI.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.OptionenViewModels
{
    public class InfoViewModel : ViewModelBasis
    {
        public InfoViewModel()
        {
            Info = new InfoModel();
            Title = "Info";
        }


        public void SetInfos(string version, DateTime release)
        {
            Info.ReleaseFronted = release;
            Info.VersionFrontend = version;

            RaisePropertyChanged("Info");
        }

        public InfoModel Info { get; set; }
    }
}
