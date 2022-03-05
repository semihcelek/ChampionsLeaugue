using SemihCelek.ChampionsLeague.Models.Matches;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Controllers
{
    public class PrepareFinalRound
    {
        private readonly ITeamRankSort _groupSorter;
        private readonly IGroupTeamReducer _groupTeamReducer;
        private readonly TeamStatsReset _teamStatsReset;
        private readonly IDrawTeams _finalDraw;

        public PrepareFinalRound(ITeamRankSort groupSorter, IGroupTeamReducer groupTeamReducer,
            TeamStatsReset teamStatsReset, IDrawTeams finalDraw)
        {
            _groupSorter = groupSorter;
            _groupTeamReducer = groupTeamReducer;
            _teamStatsReset = teamStatsReset;
            _finalDraw = finalDraw;
        }

        public void PrepareFinal()
        {
            _groupSorter.SortTeamsInTheirGroups();
            
            _groupTeamReducer.RemoveEliminatedTeams();
            
            _teamStatsReset.ResetTeamsPointsAndGoals();
            
            _finalDraw.Draw();
            
        }
    }
}