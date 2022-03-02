using System.Collections.Generic;

namespace SemihCelek.ChampionsLeague.Models.DrawGroups
{
    public class GroupModel : IGroupModel
    {
        private char _groupName;
        private List<ITeamModel> _competingTeams;

        public GroupModel(char groupName)
        {
            _groupName = groupName;
            _competingTeams = new List<ITeamModel>(4);
        }
        
        public char GetGroupName()
        {
            return _groupName;
        }

        public List<ITeamModel> GetCompetingTeamsList()
        {
            return _competingTeams;
        }

        public void AddTeamToGroup(ITeamModel teamToAdd)
        {
            _competingTeams.Add(teamToAdd);
        }
    }
}