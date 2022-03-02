using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Persistence.Repositories;

namespace SemihCelek.ChampionsLeague.Models.Matches.GroupMatches
{
    public class GroupMatchPlanner : IMatchPlanner
    {
        private readonly IGroupModel _groupModel;

        private readonly IMatchPerformer _matchPerformer;

        private readonly List<ITeamModel> _teams;

        public GroupMatchPlanner(IGroupModel groupModel, IMatchPerformer matchPerformer)
        {
            _groupModel = groupModel;
            _matchPerformer = matchPerformer;

            _teams = _groupModel.GetCompetingTeamsList();
        }
        
        public void PlanMatches()
        {
            _matchPerformer.PerformMatch(_teams[1],_teams[2]);
            _matchPerformer.PerformMatch(_teams[0],_teams[3]);
            
            _matchPerformer.PerformMatch(_teams[0],_teams[1]);
            _matchPerformer.PerformMatch(_teams[2],_teams[3]);
            
            _matchPerformer.PerformMatch(_teams[2],_teams[0]);
            _matchPerformer.PerformMatch(_teams[1],_teams[3]);
            
            _matchPerformer.PerformMatch(_teams[0],_teams[2]);
            _matchPerformer.PerformMatch(_teams[3],_teams[1]);
            
            _matchPerformer.PerformMatch(_teams[2],_teams[1]);
            _matchPerformer.PerformMatch(_teams[0],_teams[3]);
            
            _matchPerformer.PerformMatch(_teams[1],_teams[0]);
            _matchPerformer.PerformMatch(_teams[3],_teams[2]);
            
        }
    }
}