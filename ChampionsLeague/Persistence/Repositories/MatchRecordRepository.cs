using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;

namespace SemihCelek.ChampionsLeague.Persistence.Repositories
{
    public class MatchRecordRepository : IMatchRecordRepository
    {
        private List<IMatchRecordModel> _matchRecords;

        public MatchRecordRepository()
        {
            _matchRecords = new List<IMatchRecordModel>();
        }
        
        public List<IMatchRecordModel> GetMatchRecords()
        {
            return _matchRecords;
        }

        public void AddNewRecords(IMatchRecordModel matchRecord)
        {
            _matchRecords.Add(matchRecord);
        }
    }
}