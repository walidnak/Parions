using Caliburn.Micro;
using Parions.Assistants;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Parions.ViewModels
{
    class QuestionsViewModel : Screen
    {
        public static string Name = "Serveur";

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

        private string _question { get; set; }
        public string Question
        {
            get => _question;
            set
            {
                _question = value;
                NotifyOfPropertyChange();
            }
        }


        private string _OuiEstime { get; set; }
        public string OuiEstime
        {
            get => _OuiEstime;
            set
            {
                if (value.AreDigitsOnly())
                    _OuiEstime = value;
                NotifyOfPropertyChange();
            }
        }


        private bool _UnOui { get; set; }
        public bool UnOui
        {
            get => _UnOui;
            set
            {
                _UnOui = value;
                NotifyOfPropertyChange();
            }
        }


        private bool _UnNon { get; set; }
        public bool UnNon
        {
            get => _UnNon;
            set
            {
                _UnNon = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _btnVisibility { get; set; }
        public Visibility BtnVisibility { get => _btnVisibility; set { _btnVisibility = value; NotifyOfPropertyChange(); } }


        public QuestionsViewModel()
        {
            NomDutilisateur = Name;
            BtnVisibility = Visibility.Visible;
            UnOui = true;
            UnNon = false;
            Parions.Assistants.CreerUnServeur.realeaseBtnQuestions += resetBtnVisibility;
            RejoindreLequipe.BouttonSuivantQuestions += resetBtnVisibility;
        }

        public static bool IsServer = false;

        public void SetQuestion(int index)
        {
            var genQuestion = new PoserQuestions();
            Question = genQuestion.Questions[index].Question;
        }

        public void ProchainCommande()
        {
            if (string.IsNullOrEmpty(OuiEstime))
            {
                MessageBox.Show("certains champs sont vides");
                return;
            }

            var str = (UnOui == true) ? "Oui" : "Non";

            BtnVisibility = Visibility.Hidden;

            if (IsServer == false)
                RejoindreLequipe.sendMessage($"QT:{str}:{OuiEstime}");

            else
                Parions.Assistants.CreerUnServeur.RajouReponse(str, Int32.Parse(OuiEstime));

        }

        private void resetBtnVisibility(string nombreDeOui, bool done)
        {
            var conductor = this.Parent as IConductor;

            if (done == false)
            {
                ValidationsViewModel validationsViewModel = new ValidationsViewModel();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    BtnVisibility = Visibility.Visible;
                    validationsViewModel.InitBln(nombreDeOui);
                    conductor.ActivateItemAsync(validationsViewModel);
                });
            }

            else
            {
                ScoreViewModel ScoreViewModel = new ScoreViewModel();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    BtnVisibility = Visibility.Visible;
                    ScoreViewModel.loadData();
                    conductor.ActivateItemAsync(ScoreViewModel);
                });
            }
        }

    }
}
