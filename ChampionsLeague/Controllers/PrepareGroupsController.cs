using SemihCelek.ChampionsLeague.Models.DrawGroups;
using SemihCelek.ChampionsLeague.Models.PotGroups;

namespace SemihCelek.ChampionsLeague.Controllers
{
    public class PrepareGroupsController
    {
        private readonly TeamPotAdjuster _teamPotAdjuster;
        private readonly PotRandomizer _potRandomizer;
        private readonly GroupDistributeController _groupDistributeController;

        public PrepareGroupsController(TeamPotAdjuster teamPotAdjuster, PotRandomizer potRandomizer,
            GroupDistributeController groupDistributeController)
        {
            _teamPotAdjuster = teamPotAdjuster;
            _potRandomizer = potRandomizer;
            _groupDistributeController = groupDistributeController;
        }

        public void PrepareGroupsForStartingGroupMatches()
        {
            _teamPotAdjuster.DistributeTeamsToPots();

            _potRandomizer.ShuffleTeamsAtTheirPots();

            _groupDistributeController.DistributeTeamsToGroups();
        }
    }
}