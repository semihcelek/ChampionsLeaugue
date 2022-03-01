using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Models.PotGroups
{
    public class PotRandomizer
    {
        private readonly IPotRepository _potRepository;

        public PotRandomizer(IPotRepository potRepository)
        {
            _potRepository = potRepository;
        }

        public void ShuffleTeamsAtTheirPots()
        {
            List<List<IInitialTeamModel>> potList = _potRepository.GetInitialTeamPotList();
            List<List<IInitialTeamModel>> randomizedPotList = new List<List<IInitialTeamModel>>(4);

            for (int i = 0; i < potList.Count; i++)
            {
                List<IInitialTeamModel> shuffledPot = ListShuffler.ShuffleList(potList[i]);
                randomizedPotList.Add(shuffledPot);
            }

            potList = randomizedPotList;
        }
    }
}