using SemihCelek.ChampionsLeague.Models.Matches;

namespace SemihCelek.ChampionsLeague.Controllers
{
    public class ExecuteKnockOutMatchesController
    {
        private ILeagueMatchExecutor _knockoutMatchExecutor;

        public ExecuteKnockOutMatchesController(ILeagueMatchExecutor knockoutMatchExecutor)
        {
            _knockoutMatchExecutor = knockoutMatchExecutor;
        }

        public void ExecuteKnockOutMatches()
        {
            _knockoutMatchExecutor.ActLeagueMatches();
        }
    }
}