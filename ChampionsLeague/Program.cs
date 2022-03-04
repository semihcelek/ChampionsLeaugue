using SemihCelek.ChampionsLeague.Models.DrawGroups;
using SemihCelek.ChampionsLeague.Models.Matches;
using SemihCelek.ChampionsLeague.Models.Matches.GroupMatches;
using SemihCelek.ChampionsLeague.Models.PotGroups;
using SemihCelek.ChampionsLeague.Persistence;
using SemihCelek.ChampionsLeague.Persistence.Repositories;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            ITeamDataPathFinder dataPathFinder = new TeamDataPathFinder();

            IStorageContext localStorageContext = new LocalStorageContext(dataPathFinder);

            IInitialTeamModelRepository initialTeamModelRepository =
                new InitialTeamModelRepository(localStorageContext);

            IPotRepository potRepository = new PotRepository();

            IGroupRepository groupRepository = new GroupRepository();

            IMatchRecordRepository matchRecordRepository = new MatchRecordRepository();

            TeamPotAdjuster teamPotAdjuster = new TeamPotAdjuster(initialTeamModelRepository, potRepository);
            teamPotAdjuster.DistributeTeamsToPots();

            PotRandomizer potRandomizer = new PotRandomizer(potRepository);
            potRandomizer.ShuffleTeamsAtTheirPots();

            GroupDistributeController groupDistributeController =
                new GroupDistributeController(groupRepository, potRepository);

            groupDistributeController.DistributeTeamsToGroups();

            IMatchPerformer groupMatchPerformer = new GroupMatchPerformer(matchRecordRepository);

            ILeagueMatchExecutor groupMatchExecutor = new GroupMatchExecutor(groupRepository, groupMatchPerformer);

            groupMatchExecutor.ActLeagueMatches();

            ITeamRankSort groupSorter = new GroupMatchTeamSort(groupRepository);
            groupSorter.SortTeamsInTheirGroups();

            IGroupTeamReducer groupTeamReducer = new GroupMatchTeamReducer(groupRepository);
            groupTeamReducer.RemoveEliminatedTeams();
        }
    }
}