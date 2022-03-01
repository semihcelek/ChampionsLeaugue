using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;

namespace SemihCelek.ChampionsLeague.Models.PotGroups
{
    public class TeamPotAdjuster
    {
        private readonly IInitialTeamModelRepository _initialTeamModelRepository;
        private readonly IPotRepository _potRepository;

        public TeamPotAdjuster(IInitialTeamModelRepository initialTeamModelRepository, IPotRepository potRepository)
        {
            _initialTeamModelRepository = initialTeamModelRepository;
            _potRepository = potRepository;
        }

        public void DistributeTeamsToPots()
        {
            List<List<IInitialTeamModel>> potList = _potRepository.GetInitialTeamPotList();
            List<IInitialTeamModel> allTeams = _initialTeamModelRepository.GetAllTeams();

            for (int i = 0; i < 4; i++)
            {
                potList[i] = allTeams.FindAll(team => team.GetSeedPoint() == (i + 1));
            }
        }
    }
}