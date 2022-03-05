using SemihCelek.ChampionsLeague.Models.Matches;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Controllers
{
    public class PrepareSemiFinalController
    {
        private readonly ITeamRankSort _groupSorter;
        private readonly IGroupTeamReducer _groupTeamReducer;
        private readonly TeamStatsReset _teamStatsReset;
        private readonly IDrawTeams _semiFinalDraw;

        public PrepareSemiFinalController(ITeamRankSort groupSorter, IGroupTeamReducer groupTeamReducer,
            TeamStatsReset teamStatsReset, IDrawTeams semiFinalDraw)
        {
            _groupSorter = groupSorter;
            _groupTeamReducer = groupTeamReducer;
            _teamStatsReset = teamStatsReset;
            _semiFinalDraw = semiFinalDraw;
        }

        public void PrepareSemiFinal()
        {
            _groupSorter.SortTeamsInTheirGroups();
            
            _groupTeamReducer.RemoveEliminatedTeams();
            
            _teamStatsReset.ResetTeamsPointsAndGoals();
            
            _semiFinalDraw.Draw();
            
        }
    }
}