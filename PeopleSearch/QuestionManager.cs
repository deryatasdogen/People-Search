using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PeopleSearch
{
    public class QuestionManager
    {
        private Dictionary<string, string> Answers = null;

        public QuestionManager()
        {
            Answers = new Dictionary<string, string>();
            Answers.Add("Albert Einstein", "Cool guy");
            Answers.Add("Lacuna Coil", "Cool band");
            Answers.Add("Within Temptation", "Cooler band");
            Answers.Add("Harry Potter", "⚡");
        }

        public string GiveAnswer(string question)
        {
            Regex regex = new Regex(@"^(Who is|What is|Where is)\s+");
            string questionRoot = regex.Replace(question, "");

            if (!Answers.ContainsKey(questionRoot))
                return null;

            return Answers[questionRoot];

            return null;
        }

        public void AskQuestion()
        {
            Console.WriteLine("Sorunuzu Giriniz!");
            string question = Console.ReadLine();
            string answer = GiveAnswer(question);

            if (string.IsNullOrEmpty(answer))
                Console.WriteLine("Soru Bulunamadı!");
            else
                Console.WriteLine(answer);

            AskQuestion();
        }
    }
}
