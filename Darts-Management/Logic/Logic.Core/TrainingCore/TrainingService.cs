﻿using Darts.Data.Infrastructure.TrainingRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Darts.Data.Model.TrainingEntitys;
using Darts.Data.Infrastructure.SpielerRepositorys;
using Darts.Logic.Core.SpielerCore.Exceptions;

namespace Darts.Logic.Core.TrainingCore
{
    public class TrainingService
    {
        private readonly TrainingRepository repo;
        private readonly TrainingSpielerRepository trainingSpielerRepository;
        private readonly BestleistungRepository besteleistungRepository;

        public TrainingService()
        {
            repo = new TrainingRepository();
            besteleistungRepository = new BestleistungRepository();
            trainingSpielerRepository = new TrainingSpielerRepository();
        }

        public bool IstEinTrainingAktuellAktiv => repo.IstEinTrainingAktiv();

        public Training LadeAktivesTraining => repo.LadeAktivesTraining();

        public void NeuesTrainingErstellen()
        {
            var Training = new Training { Aktiv = true, Start = DateTime.Now };
            repo.Speichern(Training);
        }

        public void BeendeAktivesTraining(int trainingID)
        {
            Training training = repo.LadeByID(trainingID);
            training.Ende = DateTime.Now;
            training.Aktiv = false;
            repo.Speichern(training);
        }

        public void FuegeSpielerHinzu(int spielerID, int trainingID)
        {
            trainingSpielerRepository.Speichern(new TrainingSpieler
            {
                AngemeldetAm = DateTime.Now,
                SpielerID = spielerID,
                TrainingID = trainingID
            });
        }

        public void EntferneSpieler(int trainingSpielerID)
        {
            if (besteleistungRepository.HatTrainingSpielerEinEintrag(trainingSpielerID))
            {
                throw new TrainingSpielerHatBestleistungException();
            }
            trainingSpielerRepository.Entfernen(trainingSpielerID);
        }
    }
}