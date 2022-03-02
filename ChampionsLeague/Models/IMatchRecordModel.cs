using SemihCelek.ChampionsLeague.Models.Matches;
using SemihCelek.ChampionsLeague.Models.Matches.MatchResults;

namespace SemihCelek.ChampionsLeague.Models
{
    public interface IMatchRecordModel
    {
        ITeamModel GetHomeTeam();
        ITeamModel GetAwayTeam();
        IMatchResultStatus GetMatchResult();
        
    }
}