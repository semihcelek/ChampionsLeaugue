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
            
            IMatchPerformer groupMatchPerformer = new GroupMatchPerformer(matchRecordRepository);

            ILeagueMatchExecutor groupMatchExecutor = new GroupMatchExecutor(groupRepository, groupMatchPerformer);

            ExecuteGroupMatchesController groupMatchesController =
                new ExecuteGroupMatchesController(groupMatchExecutor);
            
            ITeamRankSort groupSorter = new GroupMatchTeamSort(groupRepository);

            IGroupTeamReducer groupTeamReducer = new GroupMatchTeamReducer(groupRepository);

            TeamStatsReset teamStatsReset = new TeamStatsReset(groupRepository);

            IDrawTeams knockoutDraw = new DrawKnockOutTeams(groupRepository);

            PrepareKnockOutMatchesController prepareKnockOutMatchesController =
                new PrepareKnockOutMatchesController(groupSorter, groupTeamReducer, teamStatsReset, knockoutDraw);
            
            ILeagueMatchExecutor knockoutMatchExecutor =
                new KnockoutMatchExecutor(groupRepository, groupMatchPerformer);

            ExecuteKnockOutMatchesController executeKnockOutMatchesController =
                new ExecuteKnockOutMatchesController(knockoutMatchExecutor);
            
            IDrawTeams quarterFinalDraw = new DrawFinalRoundTeam(groupRepository);

            PrepareQuarterFinalController quarterFinalController =
                new PrepareQuarterFinalController(groupSorter, groupTeamReducer, teamStatsReset, quarterFinalDraw);
            
            ILeagueMatchExecutor quarterFinalExecutor = new KnockoutMatchExecutor(groupRepository, groupMatchPerformer);

            ExecuteQuarterFinalController executeQuarterFinalController =
                new ExecuteQuarterFinalController(quarterFinalExecutor);

            IDrawTeams semiFinalDraw = new DrawFinalRoundTeam(groupRepository);

            PrepareSemiFinalController prepareSemiFinalController =
                new PrepareSemiFinalController(groupSorter, groupTeamReducer, teamStatsReset, semiFinalDraw);
            
            ILeagueMatchExecutor semiFinalExecutor = new KnockoutMatchExecutor(groupRepository, groupMatchPerformer);

            SemiFinalController semiFinalController = new SemiFinalController(semiFinalExecutor);

            IDrawTeams finalDraw = new DrawFinalRoundTeam(groupRepository);

            PrepareFinalRound prepareFinalRound =
                new PrepareFinalRound(groupSorter, groupTeamReducer, teamStatsReset, finalDraw);
            
            ILeagueMatchExecutor finalMatch = new KnockoutMatchExecutor(groupRepository, groupMatchPerformer);
            
            FinalController finalController = new FinalController(finalMatch);

            prepareTeams.PrepareGroupsForStartingGroupMatches();

            groupMatchesController.ExecuteGroupMatches();

            prepareKnockOutMatchesController.PrepareKnockOutMatches();

            executeKnockOutMatchesController.ExecuteKnockOutMatches();

            quarterFinalController.PrepareQuarterFinal();

            TeamGroupListAdapter.LowerRepositoryListCapacityForNextPhase(groupRepository);

            executeQuarterFinalController.ExecuteQuarterFinals();

            prepareSemiFinalController.PrepareSemiFinal();

            TeamGroupListAdapter.LowerRepositoryListCapacityForNextPhase(groupRepository);

            semiFinalController.ExecuteSemiFinalMatches();

            prepareFinalRound.PrepareFinal();

            TeamGroupListAdapter.LowerRepositoryListCapacityForNextPhase(groupRepository);

            finalController.ExecuteFinalMatch();

            groupSorter.SortTeamsInTheirGroups();
            groupTeamReducer.RemoveEliminatedTeams();
        }
    }
}