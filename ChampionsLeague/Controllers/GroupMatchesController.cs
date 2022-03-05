using SemihCelek.ChampionsLeague.Models.Matches;

namespace SemihCelek.ChampionsLeague.Controllers
{
    public class ExecuteGroupMatchesController
    {
        private ILeagueMatchExecutor _groupMatchExecutor;

        public ExecuteGroupMatchesController(ILeagueMatchExecutor groupMatchExecutor)
        {
            _groupMatchExecutor = groupMatchExecutor;
        }

        public void ExecuteGroupMatches()
        {
            _groupMatchExecutor.ActLeagueMatches();
        }
    }
}