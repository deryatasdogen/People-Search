using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleSearch
{
    public class QuestionManager
    {
        private Dictionary<string, string> Answers = null;

        public QuestionManager()
        {
            Answers = new Dictionary<string, string>();
            Answers.Add("Kütüphanede kaç adet kitap vardır?", "28765");
            Answers.Add("Kütüphanede kaç tür kitap vardır?", "22");
            Answers.Add("Harry Potterın yazarı kimdir?", "J. K. Rowling");
            Answers.Add("Harry Potter ne tür bir romandır?", "Fantastik Kurgu");
        }

        public string GiveAnswer(string question)
        {
            if (!Answers.ContainsKey(question))
                return null;

            return Answers[question];
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
