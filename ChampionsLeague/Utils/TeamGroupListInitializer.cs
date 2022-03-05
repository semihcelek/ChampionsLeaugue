using System;
using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;
using SemihCelek.ChampionsLeague.Models.DrawGroups;

namespace SemihCelek.ChampionsLeague.Utils
{
    public static class TeamGroupListInitializer
    {
        public static List<IGroupModel> InitializeTeamGroupList(int groupSize)
        {
            List<IGroupModel> competingGroups = new List<IGroupModel>(groupSize);
            for (int i = 0; i < 8; i++)
            {
                char groupName = Convert.ToChar(i + 65);
                competingGroups.Add(new GroupModel(groupName));
            }

            return competingGroups;
        }
    }
}