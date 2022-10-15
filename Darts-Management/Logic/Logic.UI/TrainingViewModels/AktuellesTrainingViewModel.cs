using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.SpielerCore.Exceptions;
using Darts.Logic.Core.TrainingCore;
using Darts.Logic.Messages.AuswahlMessages;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.Messages.TrainingMessages;
using Darts.Logic.Models.TrainingModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Darts.Logic.UI.TrainingViewModels
{
    public class AktuellesTrainingViewModel : ViewModelUebersicht<AktuellesTrainingSpielerModel, StammdatenTypes>
    {
        private readonly TrainingService trainingService;
        private bool trainingAktiv;
        private AktuellesTrainingModel aktuellesTraining;
        public AktuellesTrainingViewModel()
        {
            TrainingAktiv = false;
            Title = "Aktuelles Training";
            trainingService = new TrainingService();
            aktuellesTraining = new AktuellesTrainingModel();
            BeendeTrainingCommand = new RelayCommand(() => ExecuteBeendeTrainingCommand());
            TrageBestleistungEinCommand = new RelayCommand(() => ExecuteTrageBesteWerteEinCommand());
        }

        public async void CheckAktuellesTraining()
        {
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();

            await Task.Factory.StartNew( () => { return !trainingService.IstEinTrainingAktuellAktiv; })
                        .ContinueWith(r =>
                        {
                            if (r.Result)
                            {
                                Messenger.Default.Send(new OpenBestaetigungViewMessage { Beschreibung = "Neues Training starten?", Command = TrainingStartenCommand }, "AktuellesTraining");
                            }
                            else
                            {
                                LoadData();
                            }
                        }, scheduler);
        }

        public bool TrainingAktiv
        {
            get => trainingAktiv;
            set
            {
                trainingAktiv = value;
                RaisePropertyChanged(nameof(TrainingAktiv));
            }
        }
        public ICommand BeendeTrainingCommand { get; set; }
        public ICommand TrageBestleistungEinCommand { get; set; }

        private async void TrainingStartenCommand()
        {
            await Task.Run(() =>
            {
                trainingService.NeuesTrainingErstellen();
                LoadData();
            });
        }
        private void BeendeTraining()
        {
            TrainingAktiv = false;
            trainingService.BeendeAktivesTraining(aktuellesTraining.TrainingID);
            aktuellesTraining = new AktuellesTrainingModel();
            ItemList = new ObservableCollection<AktuellesTrainingSpielerModel>();

        }
        private void SpielerAuswahlCallback(bool confirmed, int id)
        {
            if (confirmed)
            {
                trainingService.FuegeSpielerHinzu(id, aktuellesTraining.TrainingID);
                LoadData();
            }
        }

        private void ExecuteBeendeTrainingCommand()
        {
            Messenger.Default.Send(new OpenBestaetigungViewMessage { Beschreibung = "Soll das Training beendet werden?", Command = BeendeTraining }, "AktuellesTraining");
        }

        private void ExecuteTrageBesteWerteEinCommand()
        {
            Messenger.Default.Send(new OpenBestleistungMessage { SpielerID = SelectedItem.ID, SpielerTrainingID = SelectedItem.SpielerTrainingID }, "AktuellesTraining");
        }

        protected override bool LoadDataBeimCreateAusfuehren => false;
        protected override void LoadData()
        {
            TrainingAktiv = true;
            var Training = trainingService.LadeAktivesTraining;
            aktuellesTraining = new AktuellesTrainingModel
            {
                TrainingID = Training.ID,
            };
            Training.Spieler.ToList().ForEach(spieler =>
            {
                aktuellesTraining.Spieler.Add(new AktuellesTrainingSpielerModel
                {
                    ID = spieler.Spieler.ID,
                    Name = spieler.Spieler.Name,
                    Vorname = spieler.Spieler.Vorname,
                    SpielerTrainingID = spieler.ID
                });
            });
            ItemList = aktuellesTraining.Spieler;
        }
        protected override void ExecuteEntfernenCommand()
        {
            try
            {
                trainingService.EntferneSpieler(SelectedItem.SpielerTrainingID);
            }
            catch (TrainingSpielerHatBestleistungException)
            {
                SendExceptionMessage("Spieler besitzt Bestleistungen");
                return;
            }         
            base.ExecuteEntfernenCommand();
        }
        protected override void ExecuteNeuCommand()
        {
            var IDs = new List<int>();
            ItemList.ToList().ForEach(spieler =>
            {
                IDs.Add(spieler.ID);
            });
            Messenger.Default.Send(new OpenSpielerAuswahlMessage(SpielerAuswahlCallback) { VorhandeneIDs = IDs } , "AktuellesTraining");
        }

    }
}
