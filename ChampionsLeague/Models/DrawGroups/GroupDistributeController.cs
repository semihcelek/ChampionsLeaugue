using System;
using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Models.DrawGroups
{
    public class GroupDistributeController
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IPotRepository _potRepository;
        private readonly TeamModelConverter _teamModelConverter;

        public GroupDistributeController(IGroupRepository groupRepository, IPotRepository potRepository)
        {
            _groupRepository = groupRepository;
            _potRepository = potRepository;
            _teamModelConverter = new TeamModelConverter();
        }

        public void DistributeTeamsToGroups()
        {
            List<List<IInitialTeamModel>> potList = _potRepository.GetInitialTeamPotList();
            List<IGroupModel> groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < potList.Count; i++)
            {
                for (int j = 0; j < groups.Count; j++)
                {
                    IInitialTeamModel initialTeamModelFromPot = potList[i][j];
                    ITeamModel team = _teamModelConverter.ConvertInitialTeamModelToTeamModel(initialTeamModelFromPot);
                    IGroupModel currentGroup = groups[j];
                   
                    currentGroup.AddTeamToGroup(team);
                }
            }
        }
    }
}