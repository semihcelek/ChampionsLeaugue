using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Models.Matches.QuarterFinalRounds
{
    public class DrawFinalRoundTeam : IDrawTeams
    {
        private readonly IGroupRepository _groupRepository;

        private List<ITeamModel> _remainingTeamsPot;

        public DrawFinalRoundTeam(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
            _remainingTeamsPot = new List<ITeamModel>();
        }


        public void Draw()
        {
            ExtractWinnersAndRunnersToThePot();

            RandomizePot();

            DistributeTeamsToGroups();
        }

        private void ExtractWinnersAndRunnersToThePot()
        {
            List<IGroupModel> groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < groups.Count; i++)
            {
                List<ITeamModel> group = groups[i].GetCompetingTeamsList();
                _remainingTeamsPot.Add(group[0]);
            }
        }

        private void RandomizePot()
        {
            _remainingTeamsPot = ListShuffler.ShuffleList(_remainingTeamsPot);
        }

        private void DistributeTeamsToGroups()
        {
            List<IGroupModel> groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < _remainingTeamsPot.Count; i += 2)
            {
                List<ITeamModel> group = groups[i / 2].GetCompetingTeamsList();
                group[0] = _remainingTeamsPot[i];
                group.Add(_remainingTeamsPot[i + 1]);
            }
        }
    }
}