using Parions.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;
using Parions.ViewModels;

namespace Parions.Assistants
{
    public class Echo : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var Data = e.Data;

            if (Data.Contains("Nom D'utilisateur:"))
            {
                var tempSplit = Data.Split(":");
                CreerUnServeur.UsersID.Add(ID, new UtilisateurModel { NomDutilisateur = tempSplit[1], Points = 0 });
                Send("Added:Done");

                if (CreerUnServeur.UsersID.Count - 1 == CreerUnServeur.NombreDeJoueurs)
                {
                    CreerUnServeur.SaJoue = true;
                    CreerUnServeur.curOTours++;
                    var randNum = CreerUnServeur.PoserQuesAleatoire();
                    Sessions.Broadcast($"GameOn:{randNum}");
                    CreerUnServeur.realeaseBtn?.Invoke(randNum);
                }//
            }

            else if (Data.Contains("QT"))
            {
                var split = Data.Split(":");
                CreerUnServeur.ReponseDutilisateur.Add(ID, new Reponses { QuestionAnswer = split[1], Estimez = Int32.Parse(split[2]) });
                CreerUnServeur.VoirQuestion();
            }

        }

    }

    class CreerUnServeur
    {
        public static List<int> questionsDisplayed = new List<int>();
        private static WebSocketServer webSocket = new WebSocketServer("ws://127.0.0.1:2931");
        public static int NombreDeJoueurs = 0;
        public static int NombreDeTours = 0;
        public static int curOTours = 0;
        public static bool SaJoue = false;
        public static Action<int> realeaseBtn;
        public static Action<string, bool> realeaseBtnQuestions;
        public static Dictionary<string, UtilisateurModel> UsersID = new Dictionary<string, UtilisateurModel>();
        public static Dictionary<string, Reponses> ReponseDutilisateur = new Dictionary<string, Reponses>();
        public static bool answered = false;

        public CreerUnServeur()
        {
        }

        public static void VoirQuestion()
        {
            if (ReponseDutilisateur.Count - 1 == NombreDeJoueurs)
            {
                if (curOTours < NombreDeTours)
                {
                    ++curOTours;
                    var keys = ReponseDutilisateur.Keys;
                    int count = 0;
                    foreach (var key in keys)
                    {
                        var model = ReponseDutilisateur[key];
                        if (model.QuestionAnswer == "Oui")
                        {
                            ++count;
                        }
                    }


                    foreach (var key in keys)
                    {
                        if (ReponseDutilisateur[key].Estimez == count)
                        {
                            UsersID[key].Points += 2;
                        }
                    }

                    Sendmessage($"ShowResult:{count}");
                    realeaseBtnQuestions?.Invoke($"Nombre de Oui : {count}", false);
                    ReponseDutilisateur.Clear();
                }

                else
                {
                    var userModelList = new List<UtilisateurModel>();
                    var keys = UsersID.Keys;
                    foreach (var key in keys)
                    {
                        userModelList.Add(new UtilisateurModel { NomDutilisateur = UsersID[key].NomDutilisateur, Points = UsersID[key].Points });
                    }
                    string json = JsonConvert.SerializeObject(userModelList);
                    ScoreViewModel.JsonString = json;
                    Sendmessage($"Score~{json}");
                    realeaseBtnQuestions?.Invoke("", true);
                }

            }
        }

        public static void RajouReponse(string answer, int estimation)
        {
            ReponseDutilisateur.Add("NULL", new Reponses { QuestionAnswer = answer, Estimez = estimation });
            VoirQuestion();
        }

        public static int PoserQuesAleatoire()
        {
            var generator = new Random();
            PoserQuestions PoserQuestions = new PoserQuestions();

            var randomNumber = 0;
            while (true)
            {
                randomNumber = generator.Next(PoserQuestions.Questions.Count);

                bool check = false;

                foreach (var num in questionsDisplayed)
                {
                    if (num == randomNumber)
                    {
                        check = true;
                        break;
                    }
                }

                if (questionsDisplayed.Count < 1 || check == false)
                {
                    questionsDisplayed.Add(randomNumber);
                    break;
                }
            }
            return randomNumber;
        }

        public void CommencerProcess(int OJoueurs, int OTours, Action<int> func)
        {
            answered = false;
            questionsDisplayed.Clear();
            realeaseBtn = null;
            realeaseBtn += func;
            SaJoue = false;
            realeaseBtnQuestions = null;
            curOTours = 0;
            NombreDeJoueurs = OJoueurs;
            NombreDeTours = OTours;
            UsersID.Clear();
            ReponseDutilisateur.Clear();
            webSocket?.Stop();
            webSocket.AddWebSocketService<Echo>("/Yoo");
            webSocket.Start();
            Debug.WriteLine("WS server started on ws://127.0.0.1:2931/Yoo");
            UsersID.Add("NULL", new UtilisateurModel { NomDutilisateur = "Serveur", Points = 0 });

        }

        public static void Sendmessage(string message)
        {
            webSocket.WebSocketServices.Broadcast(message);
        }

    }

}
