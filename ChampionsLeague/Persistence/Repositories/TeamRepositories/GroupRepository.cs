using System;
using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Persistence.Repositories.TeamRepositories
{
    public class GroupRepository : IGroupRepository
    {
        private List<IGroupModel> _competingGroups;

        public GroupRepository()
        {
            _competingGroups = TeamGroupListInitializer.InitializeTeamGroupList(8);
        }

        public List<IGroupModel> GetAllGroups()
        {
            return _competingGroups;
        }
    }
}