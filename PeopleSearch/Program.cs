using System;

namespace PeopleSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            QuestionManager questionManager = new QuestionManager();
            questionManager.AskQuestion();

            Console.ReadKey();
        }
    }
}
