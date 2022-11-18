using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.TrainingCore;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.Messages.TrainingMessages;
using Darts.Logic.Models.TrainingModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI.TrainingViewModels
{
    public class TrainingUebersichtViewModel : ViewModelUebersicht<TrainingUebersichtModel, StammdatenTypes>
    {
        private readonly TrainingService trainingService;
        public TrainingUebersichtViewModel()
        {
            trainingService = new TrainingService();
            Title = "Übersicht aller Trainings";
            BestleistungenCommand = new RelayCommand(() => ExecuteBestleistungenCommand());
            LoadData();
        }

        protected override int GetID() => SelectedItem.ID;
        protected override StammdatenTypes GetStammdatenTyp() => StammdatenTypes.spieler;
        protected override bool LoadDataBeimCreateAusfuehren => false;

        public ICommand BestleistungenCommand { get; set; }
        
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


        private void ExecuteBestleistungenCommand()
        {
            Messenger.Default.Send(new OpenBestleistungenVomTrainingMessage { ID = GetID()}, "TrainingUebersicht");
        }

    }
}
