using System.Collections.Generic;

namespace SemihCelek.ChampionsLeague.Models.Matches.MatchResults
{
    public interface IMatchResultStatus
    {
        List<ITeamModel> GetCompetingTeams();
        string GetMatchResult();
    }
}