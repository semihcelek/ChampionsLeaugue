using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;

namespace SemihCelek.ChampionsLeague.Models.Matches.GroupMatches
{
    public class GroupMatchTeamReducer : IGroupTeamReducer
    {
        private readonly IGroupRepository _groupRepository;

        public GroupMatchTeamReducer(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public void RemoveEliminatedTeams()
        {
            RemoveTeamsRankedThirdAndFourthAtTheirGroup();
        }

        private void RemoveTeamsRankedThirdAndFourthAtTheirGroup()
        {
            List<IGroupModel> groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < groups.Count; i++)
            {
                List<ITeamModel> group = groups[i].GetCompetingTeamsList();
                group.RemoveAt(3);
                group.RemoveAt(2);
            }
        }
    }
}