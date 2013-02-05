using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Foodle.Service.Contracts;
using Foodle.Service.Model;

namespace Foodle.Service.BL
{
    public class ResultsHandler
    {
        private static readonly string DataFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"results5.xml");

        public static SaveVoteResponse SaveVote(VoteItem voteResult)
        {
            var result = new SaveVoteResponse {Status = ResponseStatus.Unknown};

            var oldVotes = LoadResults();
            var newVotes = oldVotes.Where(t => t.Date != voteResult.Date || t.User != voteResult.User).ToList();
            //var newVotes = oldVotes;
            result.Status = (oldVotes.Count > newVotes.Count) ? ResponseStatus.Update : ResponseStatus.Inserted;

            newVotes.Add(voteResult);
            SaveResults(newVotes);

            return result;
        }

        public static Results GetResults()
        {
            var results = new Results {Items = new List<Result>()};
            var votes = LoadResults();

            foreach (var res in from d in votes.GroupBy(t => t.Date) let resultItems = votes.Where(t => t.Date == d.Key) select Calculate(d.Key, resultItems))
            {
                results.Items.Add(res);
            }

            return results;
        }

        private static Result Calculate(string date, IEnumerable<VoteItem> votes)
        {
            var rc = new ResultCollection();

            foreach (var r in votes)
            {
                rc.Add(r.Prio1, 3);
                rc.Add(r.Prio2, 2);
                rc.Add(r.Prio3, 1);
            }

            return new Result
            {
                Date = date,
                Prio1 = rc.GetResult(1),
                Prio2 = rc.GetResult(2),
                Prio3 = rc.GetResult(3)
            };
        }

        private static List<VoteItem> LoadResults()
        {
            var results = new List<VoteItem>();

            try
            {
                if (File.Exists(DataFileName))
                {
                    var deserializer = new XmlSerializer(typeof(List<VoteItem>));
                    var textReader = new StreamReader(DataFileName);
                    results = (List<VoteItem>)deserializer.Deserialize(textReader);
                    textReader.Close();
                }
            }
            catch (Exception)
            {

            }

            return results;

        }

        private static void SaveResults(List<VoteItem> results)
        {
            var serializer = new XmlSerializer(typeof(List<VoteItem>));
            var textWriter = new StreamWriter(DataFileName);
            serializer.Serialize(textWriter, results);
            textWriter.Close();
        }
    }
}