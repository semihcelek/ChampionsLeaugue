using SemihCelek.ChampionsLeague.Controllers;
using SemihCelek.ChampionsLeague.Models.DrawGroups;
using SemihCelek.ChampionsLeague.Models.Matches;
using SemihCelek.ChampionsLeague.Models.Matches.GroupMatches;
using SemihCelek.ChampionsLeague.Models.Matches.KnockoutRounds;
using SemihCelek.ChampionsLeague.Models.Matches.QuarterFinalRounds;
using SemihCelek.ChampionsLeague.Models.PotGroups;
using SemihCelek.ChampionsLeague.Persistence;
using SemihCelek.ChampionsLeague.Persistence.Repositories;
using SemihCelek.ChampionsLeague.Persistence.Repositories.TeamRepositories;
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

            PotRandomizer potRandomizer = new PotRandomizer(potRepository);

            GroupDistributeController groupDistributeController =
                new GroupDistributeController(groupRepository, potRepository);

            PrepareGroupsController prepareTeams =
                new PrepareGroupsController(teamPotAdjuster, potRandomizer,
                    groupDistributeController);

            prepareTeams.PrepareGroupsForStartingGroupMatches();

            IMatchPerformer groupMatchPerformer = new GroupMatchPerformer(matchRecordRepository);

            ILeagueMatchExecutor groupMatchExecutor = new GroupMatchExecutor(groupRepository, groupMatchPerformer);

            ExecuteGroupMatchesController groupMatchesController =
                new ExecuteGroupMatchesController(groupMatchExecutor);

            groupMatchesController.ExecuteGroupMatches();

            ITeamRankSort groupSorter = new GroupMatchTeamSort(groupRepository);

            IGroupTeamReducer groupTeamReducer = new GroupMatchTeamReducer(groupRepository);

            TeamStatsReset teamStatsReset = new TeamStatsReset(groupRepository);

            IDrawTeams knockoutDraw = new DrawKnockOutTeams(groupRepository);

            PrepareKnockOutMatchesController prepareKnockOutMatchesController =
                new PrepareKnockOutMatchesController(groupSorter, groupTeamReducer, teamStatsReset, knockoutDraw);

            prepareKnockOutMatchesController.PrepareKnockOutMatches();

            ILeagueMatchExecutor knockoutMatchExecutor =
                new KnockoutMatchExecutor(groupRepository, groupMatchPerformer);

            ExecuteKnockOutMatchesController executeKnockOutMatchesController =
                new ExecuteKnockOutMatchesController(knockoutMatchExecutor);
            executeKnockOutMatchesController.ExecuteKnockOutMatches();


            IDrawTeams quarterFinalDraw = new DrawFinalRoundTeam(groupRepository);

            PrepareQuarterFinalController quarterFinalController =
                new PrepareQuarterFinalController(groupSorter, groupTeamReducer, teamStatsReset, quarterFinalDraw);
            quarterFinalController.PrepareQuarterFinal();


            TeamGroupListAdapter.LowerRepositoryListCapacityForNextPhase(groupRepository);

            ILeagueMatchExecutor quarterFinalExecutor = new KnockoutMatchExecutor(groupRepository, groupMatchPerformer);

            ExecuteQuarterFinalController executeQuarterFinalController =
                new ExecuteQuarterFinalController(quarterFinalExecutor);
            executeQuarterFinalController.ExecuteQuarterFinals();

            IDrawTeams semiFinalDraw = new DrawFinalRoundTeam(groupRepository);

            PrepareSemiFinalController prepareSemiFinalController =
                new PrepareSemiFinalController(groupSorter, groupTeamReducer, teamStatsReset, semiFinalDraw);

            prepareSemiFinalController.PrepareSemiFinal();

            TeamGroupListAdapter.LowerRepositoryListCapacityForNextPhase(groupRepository);

            ILeagueMatchExecutor semiFinalExecutor = new KnockoutMatchExecutor(groupRepository, groupMatchPerformer);

            SemiFinalController semiFinalController = new SemiFinalController(semiFinalExecutor);
            semiFinalController.ExecuteSemiFinalMatches();

            IDrawTeams finalDraw = new DrawFinalRoundTeam(groupRepository);

            PrepareFinalRound prepareFinalRound =
                new PrepareFinalRound(groupSorter, groupTeamReducer, teamStatsReset, finalDraw);

            prepareFinalRound.PrepareFinal();

            TeamGroupListAdapter.LowerRepositoryListCapacityForNextPhase(groupRepository);

            ILeagueMatchExecutor finalMatch = new KnockoutMatchExecutor(groupRepository, groupMatchPerformer);
            FinalController finalController = new FinalController(finalMatch);
            finalController.ExecuteFinalMatch();
            
            groupSorter.SortTeamsInTheirGroups();
            groupTeamReducer.RemoveEliminatedTeams();
        }
    }
}