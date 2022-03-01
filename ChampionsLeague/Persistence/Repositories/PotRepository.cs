using System;
using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;

namespace SemihCelek.ChampionsLeague.Persistence.Repositories
{
    public class PotRepository : IPotRepository
    {
        private List<List<IInitialTeamModel>> _potList;

        public PotRepository()
        {
            InitializePotLists();
        }

        private void InitializePotLists()
        {
            _potList = new List<List<IInitialTeamModel>>(4);

            for (int i = 0; i < 4; i++)
            {
                _potList.Add(new List<IInitialTeamModel>(8));
            }
        }

        public List<List<IInitialTeamModel>> GetInitialTeamPotList()
        {
            return _potList;
        }
    }
}