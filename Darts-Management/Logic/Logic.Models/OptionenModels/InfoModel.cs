using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Models.OptionenModels
{
    public class InfoModel
    {
        public string VersionBackend { get; set; }
        public string VersionFrontend { get; set; }
        public DateTime ReleaseBackend { get; set; }
        public DateTime ReleaseFronted { get; set; }
    }
}
