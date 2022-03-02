using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;

namespace SemihCelek.ChampionsLeague.Models.Matches.GroupMatches
{
    public class GroupMatchExecutor : ILeagueMatchExecutor
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMatchPerformer _groupMatchPerformer;

        public GroupMatchExecutor(IGroupRepository groupRepository, IMatchPerformer groupMatchPerformer)
        {
            _groupRepository = groupRepository;
            _groupMatchPerformer = groupMatchPerformer;
        }

        public void ActLeagueMatches()
        {
            IterateThroughEachGroupAndPlanTheirMatches();
        }

        private void IterateThroughEachGroupAndPlanTheirMatches()
        {
            List<IGroupModel> groups = _groupRepository.GetAllGroups();

            for (int i = 0; i < groups.Count; i++)
            {
                IGroupModel group = groups[i];
                IMatchPlanner groupMatchPlanner = new GroupMatchPlanner(@group, _groupMatchPerformer);
                groupMatchPlanner.PlanMatches();
            }
        }
    }
}