using Caliburn.Micro;
using Parions.Assistants;
using System.Threading.Tasks;
using System.Windows;

namespace Parions.ViewModels
{
    class RejoindreLequipeViewModel : Screen
    {
        private string _NomDutilisateur { get; set; }
        public string NomDutilisateur
        {
            get => _NomDutilisateur;
            set
            {
                _NomDutilisateur = value;
                NotifyOfPropertyChange();
            }
        }

        private string _server_Url { get; set; }
        public string ServerUrl
        {
            get => _server_Url;
            set
            {
                _server_Url = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _btnVisibility { get; set; }
        public Visibility BtnVisibility { get => _btnVisibility; set { _btnVisibility = value; NotifyOfPropertyChange(); } }

        public RejoindreLequipeViewModel()
        {
            BtnVisibility = Visibility.Visible;
            ServerUrl = "ws://127.0.0.1:2931/Yoo"; // Par default
        }

        public void RejoindreCommande()
        {
            if (string.IsNullOrEmpty(NomDutilisateur) || string.IsNullOrEmpty(ServerUrl))
            {
                MessageBox.Show("champ vide");
                return;
            }

            QuestionsViewModel.Name = NomDutilisateur;

            BtnVisibility = Visibility.Hidden;
            Task.Run(() =>
            {
                RejoindreLequipe.connecterAuServeur(ServerUrl, NomDutilisateur, resetBtnVisibility);
            });
        }

        private void resetBtnVisibility(int index)
        {
            var conductor = this.Parent as IConductor;
            Application.Current.Dispatcher.Invoke(() =>
            {
                BtnVisibility = Visibility.Visible;
                var questionViewModel = new QuestionsViewModel();
                QuestionsViewModel.IsServer = false;
                questionViewModel.SetQuestion(index);
                conductor.ActivateItemAsync(questionViewModel);
            });
        }

    }
}
