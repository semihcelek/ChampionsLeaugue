using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;

namespace SemihCelek.ChampionsLeague.Models.Matches.GroupMatches
{
    public class GroupMatchTeamSort : ITeamRankSort
    {
        private readonly IGroupRepository _groupRepository;

        public GroupMatchTeamSort(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        
        public void SortTeamsInTheirGroups()
        {
            List<IGroupModel> _groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < _groups.Count; i++)
            {
                SortTeams(_groups[i]);
            }
        }

        private void SortTeams(IGroupModel group)
        {
            List<ITeamModel> competingTeams = group.GetCompetingTeamsList();
            competingTeams.Sort((team, teamToCompare) => -team.GetPoints().CompareTo(teamToCompare.GetPoints()));
        }
    }
}