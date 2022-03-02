using System.Collections.Generic;

namespace SemihCelek.ChampionsLeague.Models.Matches.MatchResults
{
    public class WinningMatchResult : IMatchResultStatus
    {
        private readonly ITeamModel _wonTeam;
        private readonly ITeamModel _lostTeam;
        private readonly int _wonTeamGoals;
        private readonly int _lostTeamGoals;

        public WinningMatchResult(ITeamModel wonTeam, ITeamModel lostTeam, int wonTeamGoals, int lostTeamGoals)
        {
            _wonTeam = wonTeam;
            _lostTeam = lostTeam;
            _wonTeamGoals = wonTeamGoals;
            _lostTeamGoals = lostTeamGoals;

            UpdateTeamAccordingToMatchResult();
        }

        private void UpdateTeamAccordingToMatchResult()
        {
            _wonTeam.AddGoals(_wonTeamGoals);
            _wonTeam.AddPoints(3);

            _lostTeam.AddGoals(_lostTeamGoals);
            _lostTeam.AddPoints(0);
        }
        
        public List<ITeamModel> GetCompetingTeams()
        {
            List<ITeamModel> teamModels = new List<ITeamModel>();
            teamModels.Add(_wonTeam);
            teamModels.Add(_lostTeam);

            return teamModels;
        }

        public string GetMatchResult()
        {
            return "Winning!";
        }
    }
}