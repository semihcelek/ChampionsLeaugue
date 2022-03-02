using System.Collections.Generic;

namespace SemihCelek.ChampionsLeague.Models.Matches.MatchResults
{
    public class DrawMatchResult : IMatchResultStatus
    {
        private readonly ITeamModel _homeTeam;
        private readonly ITeamModel _awayTeam;
        private readonly int _goals;

        public DrawMatchResult(ITeamModel homeTeam, ITeamModel awayTeam, int goals)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _goals = goals;
            
            UpdateTeamAccordingToMatchResult();
        }

        private void UpdateTeamAccordingToMatchResult()
        {
            _homeTeam.AddGoals(_goals);
            _homeTeam.AddPoints(1);

            _awayTeam.AddGoals(_goals);
            _awayTeam.AddPoints(1);
        }

        public List<ITeamModel> GetCompetingTeams()
        {
            List<ITeamModel> teamModels = new List<ITeamModel>();
            teamModels.Add(_homeTeam);
            teamModels.Add(_awayTeam);

            return teamModels;
        }

        public string GetMatchResult()
        {
            return "Draw!";
        }
    }
}