using SemihCelek.ChampionsLeague.Models.Matches;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Controllers
{
    public class PrepareKnockOutMatchesController
    {
        private ITeamRankSort _groupSorter;
        private IGroupTeamReducer _groupTeamReducer;
        private TeamStatsReset _teamStatsReset;
        private IDrawTeams _knockoutDraw;

        public PrepareKnockOutMatchesController(ITeamRankSort groupSorter, IGroupTeamReducer groupTeamReducer,
            TeamStatsReset teamStatsReset, IDrawTeams knockoutDraw)
        {
            _groupSorter = groupSorter;
            _groupTeamReducer = groupTeamReducer;
            _teamStatsReset = teamStatsReset;
            _knockoutDraw = knockoutDraw;
        }

        public void PrepareKnockOutMatches()
        {
            _groupSorter.SortTeamsInTheirGroups();
            
            _groupTeamReducer.RemoveEliminatedTeams();
            _groupTeamReducer.RemoveEliminatedTeams();
            
            _teamStatsReset.ResetTeamsPointsAndGoals();
            
            _knockoutDraw.Draw();
        }
    }
}