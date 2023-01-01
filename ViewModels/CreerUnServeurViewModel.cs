using Caliburn.Micro;
using Parions.Assistants;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Parions.ViewModels
{
    class CreerUnServeurViewModel : Screen
    {
        private string _nombre_De_Joueurs { get; set; }
        public string NombreDeJoueurs
        {
            get => _nombre_De_Joueurs;
            set
            {
                if (value.AreDigitsOnly())
                    _nombre_De_Joueurs = value;
                NotifyOfPropertyChange();
            }
        }


        private string _nombre_De_Tours { get; set; }
        public string NombreDeTours
        {
            get => _nombre_De_Tours;
            set
            {
                if (value.AreDigitsOnly())
                    _nombre_De_Tours = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _btnVisibility { get; set; }
        public Visibility BtnVisibility { get => _btnVisibility; set { _btnVisibility = value; NotifyOfPropertyChange(); } }

        public CreerUnServeurViewModel()
        {
            BtnVisibility = Visibility.Visible;
            NombreDeTours = "0";
            NombreDeJoueurs = "0";
        }

        public void CreerCommande()
        {
            if (string.IsNullOrEmpty(NombreDeJoueurs) || string.IsNullOrEmpty(NombreDeTours))
            {
                MessageBox.Show("certains champs sont vides");
                return;
            }
            var createServer = new Parions.Assistants.CreerUnServeur();
            BtnVisibility = Visibility.Hidden;

            Task.Run(() =>
            {
                createServer.CommencerProcess(Int32.Parse(NombreDeJoueurs), Int32.Parse(NombreDeTours), resetBtnVisibility);
            });
        }

        private void resetBtnVisibility(int index)
        {
            var conductor = this.Parent as IConductor;
            Application.Current.Dispatcher.Invoke(() =>
            {
                BtnVisibility = Visibility.Visible;
                var questionViewModel = new QuestionsViewModel();
                QuestionsViewModel.IsServer = true;
                questionViewModel.SetQuestion(index);
                conductor.ActivateItemAsync(questionViewModel);
            });
        }

    }

    public static class StringExtensions
    {
        public static bool AreDigitsOnly(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;

            decimal num = 0;
            return decimal.TryParse(text, out num);
        }
    }

}
