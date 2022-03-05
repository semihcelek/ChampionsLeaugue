using SemihCelek.ChampionsLeague.Models.Matches;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Controllers
{
    public class PrepareQuarterFinalController
    {
        private ITeamRankSort _groupSorter;
        private IGroupTeamReducer _groupTeamReducer;
        private TeamStatsReset _teamStatsReset;
        private IDrawTeams _quarterFinalDraw;

        public PrepareQuarterFinalController(ITeamRankSort groupSorter, IGroupTeamReducer groupTeamReducer,
            TeamStatsReset teamStatsReset, IDrawTeams quarterFinalDraw)
        {
            _groupSorter = groupSorter;
            _groupTeamReducer = groupTeamReducer;
            _teamStatsReset = teamStatsReset;
            _quarterFinalDraw = quarterFinalDraw;
        }

        public void PrepareQuarterFinal()
        {
            _groupSorter.SortTeamsInTheirGroups();
            
            _groupTeamReducer.RemoveEliminatedTeams();
            
            _teamStatsReset.ResetTeamsPointsAndGoals();
            
            _quarterFinalDraw.Draw();
            
        }
    }
}