﻿using Darts.Data.Infrastructure;
using Darts.Data.Infrastructure.SpielerRepositorys;
using Darts.Data.Model.SpielerEntitys;
using Darts.Logic.Models.AuswahlModels;
using Darts.Logic.Models.SpielerModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Core.SpielerCore
{
    public class SpielerService
    {
        private readonly SpielerRepository repo;

        public SpielerService()
        {
            repo = new SpielerRepository();
        }

        public ObservableCollection<SpielerUebersichtModel> LadeFuerUebersicht()
        {
            ObservableCollection<SpielerUebersichtModel> SpielerUebersichtList = new ObservableCollection<SpielerUebersichtModel>();

            IList<Spieler> spieler = repo.LadeAlle();

            spieler.ToList().ForEach(s =>
           {
               SpielerUebersichtList.Add(new SpielerUebersichtModel
               {
                   ID = s.ID,
                   Name = s.Name,
                   Vorname = s.Vorname
               });
           });

            return SpielerUebersichtList;
        }

        public ObservableCollection<SpielerAuswahlModel> LadeFuerAuswahl(string filterText, IList<int> vorhandendeSpieler)
        {
            ObservableCollection<SpielerAuswahlModel> SpielerAuswahlList = new ObservableCollection<SpielerAuswahlModel>();

            IList<Spieler> spieler = repo.LadeAlle(filterText, vorhandendeSpieler);

            spieler.ToList().ForEach(s =>
            {
                SpielerAuswahlList.Add(new SpielerAuswahlModel
                {
                    ID = s.ID,
                    Name = s.Name,
                    Vorname = s.Vorname
                });
            });

            return SpielerAuswahlList;
        }

        public ObservableCollection<SpielerAuswahlModel> LadeFuerAuswahl(string filterText)
        {
            ObservableCollection<SpielerAuswahlModel> SpielerAuswahlList = new ObservableCollection<SpielerAuswahlModel>();

            IList<Spieler> spieler = repo.LadeAlle(filterText);

            spieler.ToList().ForEach(s =>
            {
                SpielerAuswahlList.Add(new SpielerAuswahlModel
                {
                    ID = s.ID,
                    Name = s.Name,
                    Vorname = s.Vorname
                });
            });

            return SpielerAuswahlList;
        }

        public SpielerStammdatenModel LadeByID(int id)
        {
            Spieler spieler = repo.LadeByID(id);
            return new SpielerStammdatenModel
            {
                Name = spieler.Name,
                Vorname = spieler.Vorname,
                ID = spieler.ID
            };
        }

        public void Speichern(Spieler spieler)
        {
            _ = repo.Speichern(spieler);
        }

        public void Entfernen(int id)
        {
            _ = repo.Entfernen(id);
        }
    }
}