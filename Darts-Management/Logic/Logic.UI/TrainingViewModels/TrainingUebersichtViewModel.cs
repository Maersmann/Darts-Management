using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.TrainingCore;
using Darts.Logic.Models.TrainingModels;
using Darts.Logic.UI.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.TrainingViewModels
{
    public class TrainingUebersichtViewModel : ViewModelUebersicht<TrainingUebersichtModel, StammdatenTypes>
    {
        private readonly TrainingService trainingService;
        public TrainingUebersichtViewModel()
        {
            trainingService = new TrainingService();
            Title = "Übersicht aller Trainings";
            LoadData();
        }

        protected override int GetID() => SelectedItem.ID;
        protected override StammdatenTypes GetStammdatenTyp() => StammdatenTypes.spieler;
        protected override bool LoadDataBeimCreateAusfuehren => false;


        protected override void LoadData()
        {
            var Trainings = trainingService.LadeAlle();
            Trainings.ToList().ForEach(training =>
            {
                ItemList.Add(new TrainingUebersichtModel
                {
                    Aktiv = training.Aktiv,
                    Tag = training.Tag,
                    AnzahlShortLeg = training.AnzahlShortLeg,
                    AnzahlBullFinish = training.AnzahlBullFinish,
                    AnzahlHighfinish = training.AnzahlHighfinish,
                    AnzahlHighscore = training.AnzahlHighscore,
                    AnzahlSpieler = training.AnzahlSpieler,
                    ID = training.ID
                });
            });
        }
    }
}
