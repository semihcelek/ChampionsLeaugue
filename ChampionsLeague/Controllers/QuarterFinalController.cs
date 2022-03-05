using SemihCelek.ChampionsLeague.Models.Matches;

namespace SemihCelek.ChampionsLeague.Controllers
{
    public class ExecuteQuarterFinalController
    {
        private ILeagueMatchExecutor _quarterFinalExecutor;

        public ExecuteQuarterFinalController(ILeagueMatchExecutor quarterFinalExecutor)
        {
            _quarterFinalExecutor = quarterFinalExecutor;
        }

         public void ExecuteQuarterFinals()
        {
            _quarterFinalExecutor.ActLeagueMatches();
        }
    }
}