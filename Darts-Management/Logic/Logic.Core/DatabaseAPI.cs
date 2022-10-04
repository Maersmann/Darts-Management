using Darts.Data.Infrastructure.Base;
using Darts.Data.Infrastructure.KonvertierungRepositorys;
using Darts.Data.Types.KonvertierungTypes;
using Darts.Logic.Core.KonvertierungCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Core
{
    public class DatabaseAPI
    {
        public void AktualisereDatenbank( bool mitKonvertierung)
        {
            Database dbAPI = new Database();
            dbAPI.OpenConnection();

            if(!mitKonvertierung)
            {
                return;
            }

            var konv = new KonvertierungRepository();


            if (!konv.IstVorhandenAsync(KonvertierungTypes.dartuser))
            {
                new KonvertierungDartUser().Start();
                konv.Speichern(KonvertierungTypes.dartuser);
            }
        }
    }
}
