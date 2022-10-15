using Darts.Data.Model.SpielerEntitys;
using Darts.Data.Types.BaseTypes;
using Darts.Data.Types.SpielerTypes;
using Darts.Logic.Core.SpielerCore;
using Darts.Logic.Messages.SpielerMessages;
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
    public class AktuellesTrainingSpielerBestleistungViewModel : ViewModelUebersicht<AktuellesTrainingSpielerBestleistungModel, StammdatenTypes>
    {
        private readonly BestleistungService bestleistungService;
        private int spielerID;
        private int trainingSpielerID;

        public AktuellesTrainingSpielerBestleistungViewModel()
        {
            Title = "Bestleistung";
            HundertAchtzigCommand = new RelayCommand(() => ExecuteHundertAchtzigCommand());
            HighScoreCommand = new RelayCommand(() => ExecuteHighScoreCommand());
            HighFinishCommand = new RelayCommand(() => ExecuteHighFinishCommand());
            BullFinishCommand = new RelayCommand(() => ExecuteBullFinishCommand());
            ShortLegCommand = new RelayCommand(() => ExecuteShortLegCommand());

            bestleistungService = new BestleistungService();
        }


        public ICommand HundertAchtzigCommand { get; set; }
        public ICommand HighScoreCommand { get; set; }
        public ICommand HighFinishCommand { get; set; }
        public ICommand BullFinishCommand { get; set; }
        public ICommand ShortLegCommand { get; set; }

        private void ExecuteHundertAchtzigCommand()
        {
            bestleistungService.NeueBestleistung(BestleistungHerkunft.training, BestleistungArt.highscore, 180, spielerID, trainingSpielerID);
            LoadData();
        }
        private void ExecuteHighScoreCommand()
        {
            Messenger.Default.Send(new OpenBestwerteEintragenMessage { Art = BestleistungArt.highscore, Herkunft = BestleistungHerkunft.training, SpielerID = spielerID, TrainingSpielerID = trainingSpielerID, Callback = LoadData }, "AktuellesTrainingSpielerBestleistung");
        }
        private void ExecuteHighFinishCommand()
        {
            Messenger.Default.Send(new OpenBestwerteEintragenMessage { Art = BestleistungArt.highfinish, Herkunft = BestleistungHerkunft.training, SpielerID = spielerID, TrainingSpielerID = trainingSpielerID, Callback = LoadData }, "AktuellesTrainingSpielerBestleistung");
        }
        private void ExecuteBullFinishCommand()
        {
            bestleistungService.NeueBestleistung(BestleistungHerkunft.training, BestleistungArt.bullfinish, spielerID, trainingSpielerID);
            LoadData();
        }
        private void ExecuteShortLegCommand()
        {
            Messenger.Default.Send(new OpenBestwerteEintragenMessage { Art = BestleistungArt.shortLeg, Herkunft = BestleistungHerkunft.training, SpielerID = spielerID, TrainingSpielerID = trainingSpielerID, Callback = LoadData }, "AktuellesTrainingSpielerBestleistung");
        }

        public void LadeBesteWerteFuerSpieler(int spielerID, int trainingSpielerID)
        {
            this.spielerID = spielerID;
            this.trainingSpielerID = trainingSpielerID;
            LoadData();
        }

        protected override void LoadData()
        {
            ItemList.Clear();
            IList<Bestleistung> Besteleistungen = bestleistungService.LadeAlleFuerTrainingSpieler(trainingSpielerID);
            Besteleistungen.ToList().ForEach(bestleistung => 
            {
                ItemList.Add(new AktuellesTrainingSpielerBestleistungModel
                {
                    BestleistungArt = bestleistung.Art,
                    GeworfenAm = bestleistung.GeworfenAm.Value,
                    ID = bestleistung.ID,
                    Value = bestleistung.Value.HasValue ? bestleistung.Value.ToString() : ""
                });
            });
        }

        protected override bool LoadDataBeimCreateAusfuehren => false;

        protected override void ExecuteEntfernenCommand()
        {
            bestleistungService.Entfernen(SelectedItem.ID);
            base.ExecuteEntfernenCommand();
        }

    }
}
