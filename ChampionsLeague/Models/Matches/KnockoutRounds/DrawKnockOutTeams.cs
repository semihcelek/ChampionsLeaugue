using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Models.Matches.KnockoutRounds
{
    public class DrawKnockOutTeams : IDrawTeams
    {
        private readonly IGroupRepository _groupRepository;

        private List<ITeamModel> _winnerTeamsInGroupsPot;
        private List<ITeamModel> _runnerTeamsInGroupPot;

        public DrawKnockOutTeams(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;

            _winnerTeamsInGroupsPot = new List<ITeamModel>();
            _runnerTeamsInGroupPot = new List<ITeamModel>();
        }

        public void Draw()
        {
            ExtractWinnersAndRunnersToThePot();

            RandomizePots();

            DistributeWinnersAndRunnersToGroups();
        }
        
        private void ExtractWinnersAndRunnersToThePot()
        {
            List<IGroupModel> groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < groups.Count; i++)
            {
                List<ITeamModel> group = groups[i].GetCompetingTeamsList();
                _winnerTeamsInGroupsPot.Add(group[0]);
                _runnerTeamsInGroupPot.Add(group[1]);
            }
        }

        private void RandomizePots()
        {
            _winnerTeamsInGroupsPot = ListShuffler.ShuffleList(_winnerTeamsInGroupsPot);
            _runnerTeamsInGroupPot = ListShuffler.ShuffleList(_runnerTeamsInGroupPot);
        }

        private void DistributeWinnersAndRunnersToGroups()
        {
            List<IGroupModel> groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < groups.Count; i++)
            {
                List<ITeamModel> group = groups[i].GetCompetingTeamsList();
                group[0] = _winnerTeamsInGroupsPot[i];
                group[1] = _runnerTeamsInGroupPot[i];
            }
        }
    }
}