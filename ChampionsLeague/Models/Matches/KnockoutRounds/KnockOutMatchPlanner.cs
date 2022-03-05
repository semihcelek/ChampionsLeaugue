using System.Collections.Generic;

namespace SemihCelek.ChampionsLeague.Models.Matches.KnockoutRounds
{
    public class KnockOutMatchPlanner : IMatchPlanner
    {
        private readonly IGroupModel _groupModel;

        private readonly IMatchPerformer _matchPerformer;

        private readonly List<ITeamModel> _teams;

        public KnockOutMatchPlanner(IGroupModel groupModel, IMatchPerformer matchPerformer)
        {
            _groupModel = groupModel;
            _matchPerformer = matchPerformer;

            _teams = _groupModel.GetCompetingTeamsList();
        }

        public void PlanMatches()
        {
            _matchPerformer.PerformMatch(_teams[1],_teams[0]);
            _matchPerformer.PerformMatch(_teams[0],_teams[1]);
        }
    }
}