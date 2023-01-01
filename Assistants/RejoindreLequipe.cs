using Parions.ViewModels;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WebSocketSharp;

namespace Parions.Assistants
{
    class RejoindreLequipe
    {
        public static Action<int> BouttonConnecter;
        public static Action<string, bool> BouttonSuivantQuestions;

        public static bool Pageup = false;
        public static int CurIndex = 0;

        private static WebSocket ws;

        public RejoindreLequipe()
        {

        }

        public static void connecterAuServeur(string url, string NomDutilisateur, Action<int> func)
        {
            BouttonConnecter = null;
            BouttonConnecter += func;
            BouttonSuivantQuestions = null;

            Task.Run(() =>
            {
                ws = new WebSocket(url);
                ws.OnMessage += Rejoindre_EtapeWs;
                ws.Connect();
                ws.Send($"Nom D'utilisateur:{NomDutilisateur}");
                Thread.Sleep(1000);
            });
        }

        public static void sendMessage(string str)
        {
            Task.Run(() => { ws.Send(str); Thread.Sleep(1000); });
        }

        private static void Rejoindre_EtapeWs(object sender, MessageEventArgs e)
        {
            Debug.WriteLine(e.Data);
            var Data = e.Data;
            Console.WriteLine("Kuruuuuu");

            if (Data.Contains("Added"))
                MessageBox.Show("connecté");

            else if (Data.Contains("GameOn"))
            {
                var split = Data.Split(":");
                BouttonConnecter?.Invoke(Int32.Parse(split[1]));
            }

            else if (Data.Contains("ShowResult"))
            {

                var spilt = Data.Split(":");
                BouttonSuivantQuestions?.Invoke($"Nombre de Oui: {spilt[1]}", false);
            }

            else if (Data.Contains("Next"))
            {
                Pageup = true;
                var spilt = Data.Split(":");
                CurIndex = Int32.Parse(spilt[1]);
            }

            else if (Data.Contains("Score"))
            {
                var spilt = Data.Split("~");
                ScoreViewModel.JsonString = spilt[1];
                BouttonSuivantQuestions?.Invoke("", true);
            }
        }

    }
}
