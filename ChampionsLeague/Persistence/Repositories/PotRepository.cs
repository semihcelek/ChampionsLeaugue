using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;

namespace SemihCelek.ChampionsLeague.Persistence.Repositories
{
    public class PotRepository : IPotRepository
    {
        private List<List<IInitialTeamModel>> _potList;

        public PotRepository()
        {
            _potList = new List<List<IInitialTeamModel>>(4);
        }

        public List<List<IInitialTeamModel>> GetInitialTeamPotList()
        {
            return _potList;
        }
    }
}