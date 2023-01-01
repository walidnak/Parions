using Caliburn.Micro;
using Parions.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Parions.ViewModels
{
    class ScoreViewModel : Screen
    {
        public static string JsonString;

        private ObservableCollection<UtilisateurModel> _Score { get; set; }
        public ObservableCollection<UtilisateurModel> Score { get => _Score; set { _Score = value; NotifyOfPropertyChange(); } }

        public ScoreViewModel()
        {
            Score = new ObservableCollection<UtilisateurModel>();
        }

        public void loadData()
        {
            var dataResult = JsonConvert.DeserializeObject<List<UtilisateurModel>>(JsonString);
            foreach (var data in dataResult)
            {
                Score.Add(data);
            }
        }

    }
}
