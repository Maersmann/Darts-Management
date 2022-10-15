using Darts.Data.Infrastructure.Base;
using Darts.Data.Model.SpielerEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darts.Data.Infrastructure.SpielerRepositorys
{
    public class SpielerRepository : BaseRepository<Spieler>
    {
        public IList<Spieler> LadeAlle(string filterText)
        {
            return context.Spieler.Where(w => (w.Vorname.Trim() + " " + w.Name.Trim()).Trim().ToLower().Contains(filterText.Trim().ToLower())).ToList();
        }

        public IList<Spieler> LadeAlle(string filterText, IList<int> vorhandendeSpieler)
        {
            return context.Spieler.Where(w => (w.Vorname.Trim() + " " + w.Name.Trim()).Trim().ToLower().Contains(filterText.Trim().ToLower()) && !vorhandendeSpieler.Contains(w.ID) ).ToList();
        }
    }
}
