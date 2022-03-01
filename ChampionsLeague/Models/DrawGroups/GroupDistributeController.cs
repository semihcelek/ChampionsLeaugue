using System;
using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Models.DrawGroups
{
    public class GroupDistributeController
    {
        private IGroupRepository _groupRepository;
        private IPotRepository _potRepository;
        private TeamModelConverter _teamModelConverter;

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
                    ITeamModel team = _teamModelConverter.ConvertInitialTeamModelToTeamModel(potList[i][j]);
                    List<ITeamModel> currentGroup = groups[j].GetCompetingTeamsList();
                    currentGroup.Add(team);
                    Console.WriteLine(team.GetTeamName());
                    // After adding to the list, at the last iteration, the original list should be overriden.
                }
            }
        }
    }
}