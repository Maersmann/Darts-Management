using Darts.Data.Types.BaseTypes;
using Darts.Logic.Core.TrainingCore;
using Darts.Logic.Messages.BaseMessages;
using Darts.Logic.Models.TrainingModels;
using Darts.Logic.UI.BaseViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.TrainingViewModels
{
    public class AktuellesTrainingViewModel : ViewModelUebersicht<AktuellesTrainingModel, StammdatenTypes>
    {
        private readonly TrainingService trainingService;
        private bool trainingAktiv;
        public AktuellesTrainingViewModel()
        {
            TrainingAktiv = false;
            Title = "Aktuelles Training";
            trainingService = new TrainingService();
        }

        protected override bool LoadDataBeimCreateAusfuehren => false;

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

        private async void TrainingStartenCommand()
        {
            await Task.Run(() =>
            {
                trainingService.NeuesTrainingErstellen();
                LoadData();
            });
        }

        protected override void LoadData()
        {
            TrainingAktiv = true;
        }
    }
}
