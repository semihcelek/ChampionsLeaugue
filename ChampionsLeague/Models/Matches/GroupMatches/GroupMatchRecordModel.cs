using SemihCelek.ChampionsLeague.Models.Matches.MatchResults;

namespace SemihCelek.ChampionsLeague.Models.Matches.GroupMatches
{
    public class GroupMatchRecordModel : IMatchRecordModel
    {
        private readonly ITeamModel _homeTeam;
        private readonly ITeamModel _awayTeam;
        private readonly IMatchResultStatus _matchResult;
        
        public GroupMatchRecordModel(ITeamModel homeTeam, ITeamModel awayTeam, IMatchResultStatus matchResult)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _matchResult = matchResult;
        }
        
        public ITeamModel GetHomeTeam()
        {
            return _homeTeam;
        }

        public ITeamModel GetAwayTeam()
        {
            return _awayTeam;
        }

        public IMatchResultStatus GetMatchResult()
        {
            return _matchResult;
        }
    }
}