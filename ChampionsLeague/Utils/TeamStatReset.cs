using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;
using SemihCelek.ChampionsLeague.Persistence.Repositories;

namespace SemihCelek.ChampionsLeague.Utils
{
    public class TeamStatsReset
    {
        private readonly IGroupRepository _groupRepository;

        public TeamStatsReset(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public void ResetTeamsPointsAndGoals()
        {
            List<IGroupModel> _groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < _groups.Count; i++)
            {
                IterateThroughEachTeamInGroupAndResetTheirStats(_groups[i]);
            }
        }

        private void IterateThroughEachTeamInGroupAndResetTheirStats(IGroupModel group)
        {
            List<ITeamModel> teams = group.GetCompetingTeamsList();

            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].ResetGoals();
                teams[i].ResetPoint();
            }
        }
    }
}