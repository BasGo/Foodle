using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Foodle.Service.Model;
using System.Linq;

namespace Foodle.Service.BL
{
    public class ResultsHandler
    {
        private static readonly string DataFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"results.xml");

        public static bool SaveVote(VoteResult voteResult)
        {
            var res = LoadResults();
            res.Add(voteResult);
            SaveResults(res);

            return true;
        }

        public static List<Result> GetResults()
        {
            var result = new List<Result>();
            var votes = LoadResults();

            var days = votes.GroupBy(t => t.Date);

            //foreach (var day in days)
            //{
            //    var res = new Result {Date = day};

            //}

            return result;
        }

        private static List<VoteResult> LoadResults()
        {
            var results = new List<VoteResult>();

            try
            {
                if (File.Exists(DataFileName))
                {
                    var deserializer = new XmlSerializer(typeof(List<VoteResult>));
                    var textReader = new StreamReader(DataFileName);
                    results = (List<VoteResult>)deserializer.Deserialize(textReader);
                    textReader.Close();
                }
            }
            catch (Exception)
            {

            }

            return results;

        }

        private static void SaveResults(List<VoteResult> results)
        {
            var serializer = new XmlSerializer(typeof(List<VoteResult>));
            var textWriter = new StreamWriter(DataFileName);
            serializer.Serialize(textWriter, results);
            textWriter.Close();
        }
    }
}