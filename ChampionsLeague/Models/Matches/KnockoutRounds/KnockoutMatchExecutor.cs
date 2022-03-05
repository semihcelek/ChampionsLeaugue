using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;

namespace SemihCelek.ChampionsLeague.Models.Matches.KnockoutRounds
{
    public class KnockoutMatchExecutor : ILeagueMatchExecutor
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMatchPerformer _groupMatchPerformer;

        public KnockoutMatchExecutor(IGroupRepository groupRepository, IMatchPerformer groupMatchPerformer)
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
                IMatchPlanner groupMatchPlanner = new KnockOutMatchPlanner(@group, _groupMatchPerformer);
                groupMatchPlanner.PlanMatches();
            }
        }
    }
}