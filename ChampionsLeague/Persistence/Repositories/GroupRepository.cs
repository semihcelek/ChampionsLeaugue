using System;
using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;
using SemihCelek.ChampionsLeague.Models.DrawGroups;

namespace SemihCelek.ChampionsLeague.Persistence.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private List<IGroupModel> _competingGroups;

        public GroupRepository()
        {
            InitializeGroupList();
        }

        private void InitializeGroupList()
        {
            _competingGroups = new List<IGroupModel>(8);

            for (int i = 0; i < 8; i++)
            {
                char groupName = Convert.ToChar(i + 65);
                _competingGroups.Add(new GroupModel(groupName));
            }
        }

        public List<IGroupModel> GetAllGroups()
        {
            return _competingGroups;
        }
    }
}