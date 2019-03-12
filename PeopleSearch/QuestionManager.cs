using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace PeopleSearch
{
    public class QuestionManager
    {
        public string GiveAnswer(string question)
        {
            Regex regex = new Regex(@"^(Who is|What is|Where is)\s+");
            string questionRoot = regex.Replace(question, "");
            string encodedQuestionRoot = HttpUtility.UrlEncode(questionRoot);
            string url = $"https://api.duckduckgo.com/?q={encodedQuestionRoot}&format=json";

            WebClient client = new WebClient();
            string jsonString = client.DownloadString(url);
            DuckduckgoModel duckduckgoModel = JsonConvert.DeserializeObject<DuckduckgoModel>(jsonString);

            if (duckduckgoModel == null)
                return null;

            string responseText = duckduckgoModel.Abstract;
            string abstractSource = duckduckgoModel.AbstractSource;
            string abstractUrl = duckduckgoModel.AbstractURL;

            if (string.IsNullOrEmpty(responseText))
                return null;

            if (!string.IsNullOrEmpty(abstractSource))
                responseText += Environment.NewLine + "From: " + abstractSource;

            if (!string.IsNullOrEmpty(abstractUrl))
                responseText += Environment.NewLine + "More Detail: " + abstractUrl;

            return responseText;
        }

        public void AskQuestion()
        {
            Console.WriteLine("Who are you looking for?");
            string question = Console.ReadLine();
            string answer = GiveAnswer(question);

            if (string.IsNullOrEmpty(answer))
                Console.WriteLine("Sorry. I cannot answer that yet.");
            else
                Console.WriteLine(answer);

            AskQuestion();
        }
    }
}
