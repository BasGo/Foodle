
namespace Foodle.Service.Model
{
    public class VoteResult
    {
        public string Date { get; set; }
        public string User { get; set; }
        public Restaurant Prio1 { get; set; }
        public Restaurant Prio2 { get; set; }
        public Restaurant Prio3 { get; set; }
    }
}