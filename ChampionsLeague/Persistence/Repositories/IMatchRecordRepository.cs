using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;

namespace SemihCelek.ChampionsLeague.Persistence.Repositories
{
    public interface IMatchRecordRepository
    {
        List<IMatchRecordModel> GetMatchRecords();
        void AddNewRecords(IMatchRecordModel matchRecord);
    }
}