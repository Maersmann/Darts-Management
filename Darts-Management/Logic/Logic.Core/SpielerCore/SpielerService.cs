﻿using Darts.Data.Infrastructure;
using Darts.Data.Infrastructure.SpielerRepositorys;
using Darts.Data.Infrastructure.TrainingRepositorys;
using Darts.Data.Model.SpielerEntitys;
using Darts.Logic.Core.SpielerCore.DTO;
using Darts.Logic.Core.SpielerCore.Exceptions;
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
        private readonly TrainingSpielerRepository trainingSpielerRepository;

        public SpielerService()
        {
            repo = new SpielerRepository();
            trainingSpielerRepository = new TrainingSpielerRepository();
        }

        public IList<SpielerDTO> LadeAlle()
        {
            IList<SpielerDTO> SpielerUebersichtList = new List<SpielerDTO>();

            IList<Spieler> spieler = repo.LadeAlle();

            spieler.OrderBy(o => o.Name).ToList().ForEach(s =>
           {
               SpielerUebersichtList.Add(new SpielerDTO
               {
                   ID = s.ID,
                   Name = s.Name,
                   Vorname = s.Vorname
               });
           });

            return SpielerUebersichtList;
        }

        public IList<SpielerDTO> LadeAlle(string filterText, IList<int> vorhandendeSpieler)
        {
            IList<SpielerDTO> SpielerAuswahlList = new List<SpielerDTO>();

            IList<Spieler> spieler = repo.LadeAlle(filterText, vorhandendeSpieler);

            spieler.OrderBy(o => o.Name).ToList().ForEach(s =>
            {
                SpielerAuswahlList.Add(new SpielerDTO
                {
                    ID = s.ID,
                    Name = s.Name,
                    Vorname = s.Vorname
                });
            });

            return SpielerAuswahlList;
        }

        public IList<SpielerDTO> LadeAlle(string filterText)
        {
            IList<SpielerDTO> SpielerAuswahlList = new List<SpielerDTO>();

            IList<Spieler> spieler = repo.LadeAlle(filterText);

            spieler.OrderBy(o => o.Name).ToList().ForEach(s =>
            {
                SpielerAuswahlList.Add(new SpielerDTO
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
            spieler.Name = spieler.Name.Trim();
            spieler.Vorname = spieler.Vorname.Trim();
            _ = repo.Speichern(spieler);
        }

        public void Entfernen(int id)
        {
            if (trainingSpielerRepository.IstSpielerImTrainingVorhanden(id))
            {
                throw new SpielerImTrainingVorhandenException();
            }
            else
            {
                _ = repo.Entfernen(id);
            }     
        }

        public bool IstNameSchonVorhanden(string fullname) => repo.IstNameVorhanden(fullname);
    }
}
