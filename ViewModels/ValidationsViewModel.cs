using Caliburn.Micro;
using Parions.Assistants;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Parions.ViewModels
{
    class ValidationsViewModel : Screen
    {
        private string _Bln { get; set; }
        public string Bln
        {
            get => _Bln;
            set
            {
                _Bln = value;
                NotifyOfPropertyChange();
            }
        }

        private Visibility _btnVisibility { get; set; }
        public Visibility BtnVisibility { get => _btnVisibility; set { _btnVisibility = value; NotifyOfPropertyChange(); } }

        public ValidationsViewModel()
        {
            BtnVisibility = Visibility.Visible;
        }

        public void InitBln(string Biln) => Bln = Biln;

        public void SuivantCommande()
        {
            if (QuestionsViewModel.IsServer == true)
            {
                var conductor = this.Parent as IConductor;
                var questionViewModel = new QuestionsViewModel();
                var index = Parions.Assistants.CreerUnServeur.PoserQuesAleatoire();
                questionViewModel.SetQuestion(index);
                conductor.ActivateItemAsync(questionViewModel);
                Parions.Assistants.CreerUnServeur.Sendmessage($"Next:{index}");
            }


            else
            {
                BtnVisibility = Visibility.Hidden;
                Task.Run(() =>
                {
                    while (RejoindreLequipe.Pageup == false)
                    {
                        Thread.Sleep(1000);
                    }

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        RejoindreLequipe.Pageup = false;
                        BtnVisibility = Visibility.Visible;
                        var conductor = this.Parent as IConductor;
                        var questionViewModel = new QuestionsViewModel();
                        questionViewModel.SetQuestion(RejoindreLequipe.CurIndex);
                        conductor.ActivateItemAsync(questionViewModel);
                    });
                });
            }
        }

    }
}
