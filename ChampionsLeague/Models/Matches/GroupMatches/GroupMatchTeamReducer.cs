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
            RemoveTeamsRankedLastAtTheirGroup();
        }

        private void RemoveTeamsRankedLastAtTheirGroup()
        {
            List<IGroupModel> groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < groups.Count; i++)
            {
                List<ITeamModel> group = groups[i].GetCompetingTeamsList();
                group.RemoveAt(group.Count-1);
            }
        }
    }
}