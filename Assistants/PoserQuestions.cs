using Parions.Models;
using System.Collections.Generic;

namespace Parions.Assistants
{
    class PoserQuestions
    {
        public List<QuestionsModel> Questions { get; set; }
        public PoserQuestions()
        {
            loadQuestions();
        }

        private void loadQuestions()
        {
            Questions = new List<QuestionsModel>();
            Questions.Add(new QuestionsModel { Question = "est-ce que t'es en couple?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Est-ce que t'as fete Noel avec ta famille cette année?", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Croyez-vous que l'homme est vraiment allé sur la Lune ?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Pensez-vous qu'il y a une vie après la mort ?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "La Lune va finir par tomber sur la Terre à cause de la gravité", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Croyez-vous qu'il existe une vie semblable à celle des humains sur d'autres planètes ?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Si on vous propose de devenir un robot, accepteriez-vous ?", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Est-ce que tas fete le nouvel an avec ta famille ?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Les cinq postes au basketball sont meneur, arrière, ailier gauche, ailier droit et pivot", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Le Canada a été le premier pays à légaliser a fumer de la beu ?", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Êtes-vous en faveur de l'égalité des sexes ?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "La Lune va finir par tomber sur la Terre à cause de la gravité", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "D’une superficie de 105 km2, Paris est l’une des plus petites capitales européennes", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Vous feriez du mal à quelqu'un pour être heureux ?", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Venom a été créé par un fan de Marvel", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "À l’origine, Hulk était gris", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Avec l’anglais, le français est la seule langue présente sur les 5 continents", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Vous vivez seul ?", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Vous voulez être immortel ?", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Vous êtes un professionnel dans un domaine quelconque ?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "La ville de Marseille a été rattachée à la France en 1767", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "T'aimes toujours ton ex ?", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Êtes-vous capable d'être honnête à 100% ?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Changeriez-vous votre nom si vous le pouviez ?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "La russie est le pays le plus grand du monde »", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "La france est elle championne du monde ", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "as tu fais du ski pendant les vacances?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Zidane est ne a Lille", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "Les dauphins se fient beaucoup à leur odorat", Reponse = "No" });
            Questions.Add(new QuestionsModel { Question = "On peut visiter à Lille la maison natale de Charles de Gaulle", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Vendriez-vous votre âme pour de l'argent ?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Est-ce que t'aime manger?", Reponse = "Yes" });
            Questions.Add(new QuestionsModel { Question = "Est-ce que vous mentez souvent ?", Reponse = "No" });
        }

    }
}
