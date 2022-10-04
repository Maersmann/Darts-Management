using Darts.Data.Infrastructure.Base;
using Darts.Data.Model.KonvertierungEntitys;
using Darts.Data.Types.KonvertierungTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Data.Infrastructure.KonvertierungRepositorys
{
    public class KonvertierungRepository : BaseRepository
    {

        public KonvertierungRepository() : base() { }

        public int Speichern(KonvertierungTypes typ)
        {
            var Entity = new Konvertierung
            {
                Typ = typ
            };

            context.Konvertierungen.Add(Entity);
            return context.SaveChanges();
        }

        public bool IstVorhandenAsync(KonvertierungTypes typ)
        {
            var Aktie = context.Konvertierungen.Where(k => k.Typ.Equals(typ)).FirstOrDefault();

            return (Aktie != null);
        }
    }
}
