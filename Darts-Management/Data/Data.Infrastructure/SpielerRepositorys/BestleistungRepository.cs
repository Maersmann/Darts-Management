﻿using Darts.Data.Infrastructure.Base;
using Darts.Data.Model.SpielerEntitys;
using Darts.Data.Model.TrainingEntitys;
using Darts.Data.Types.SpielerTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darts.Data.Infrastructure.SpielerRepositorys
{
    public class BestleistungRepository : BaseRepository<Bestleistung>
    {
        public IList<Bestleistung> LadeAlleByTrainingSpielerID(int trainingSpielerID)
        {
            return context.Bestleistungen.Where(w => w.TrainingSpielerID.Equals(trainingSpielerID)).ToList();
        }

        public bool HatTrainingSpielerEinEintrag(int trainingSpielerID)
        {
            return context.Bestleistungen.FirstOrDefault(t => t.TrainingSpielerID.Equals(trainingSpielerID)) != null;
        }

        public IList<Bestleistung> LadeAlleByTrainingID(int trainingID)
        {
            return context.Bestleistungen.Where(t => t.TrainingSpieler.TrainingID.Equals(trainingID)).Include(i => i.Spieler).ToList();
        }

        public IList<Bestleistung> LadeAlleHundertAchtzig()
        {
            return context.Bestleistungen.Where(w => w.Value.Equals(180) && w.Art.Equals(BestleistungArt.highscore)).Include( i => i.Spieler).ToList();
        }

        public IList<Bestleistung> LadeAlleByArt(BestleistungArt art)
        {
            return context.Bestleistungen.Where(w => w.Art.Equals(art)).Include(i => i.Spieler).ToList();
        }

        public IList<Bestleistung> LadeAlleHundertAchtzigImJahr(int jahr)
        {
            return context.Bestleistungen.Where(w => w.Value.Equals(180) && w.Art.Equals(BestleistungArt.highscore) && w.GeworfenAm.Value.Year.Equals(jahr)).Include(i => i.Spieler).ToList();
        }

        public IList<Bestleistung> LadeAlleByArtImJahr(BestleistungArt art, int jahr)
        {
            return context.Bestleistungen.Where(w => w.Art.Equals(art) && w.GeworfenAm.Value.Year.Equals(jahr)).Include(i => i.Spieler).ToList();
        }

        public IList<Bestleistung> LadeAlleByArtImJahrundMonat(BestleistungArt art, int jahr, int monat)
        {
            return context.Bestleistungen.Where(w => w.Art.Equals(art) && w.GeworfenAm.Value.Year.Equals(jahr) && w.GeworfenAm.Value.Month.Equals(monat)).Include(i => i.Spieler).ToList();
        }

        public IList<Bestleistung> LadeAlleHundertAchtzigImJahrundMonat(int jahr, int monat)
        {
            return context.Bestleistungen.Where(w => w.Value.Equals(180) && w.Art.Equals(BestleistungArt.highscore) && w.GeworfenAm.Value.Year.Equals(jahr) && w.GeworfenAm.Value.Month.Equals(monat)).Include(i => i.Spieler).ToList();
        }

        public IList<Bestleistung> LadeAlleBySpielerID(int spielerID)
        {
            return context.Bestleistungen.Where(t => t.TrainingSpieler.SpielerID.Equals(spielerID)).Include(i => i.TrainingSpieler).ThenInclude(i => i.Training).ToList();
        }
    }
}
