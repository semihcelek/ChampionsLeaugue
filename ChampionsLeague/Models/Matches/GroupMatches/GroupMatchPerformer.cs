using System;
using SemihCelek.ChampionsLeague.Models.Matches.MatchResults;
using SemihCelek.ChampionsLeague.Persistence.Repositories;

namespace SemihCelek.ChampionsLeague.Models.Matches.GroupMatches
{
    public class GroupMatchPerformer : IMatchPerformer
    {
        private const int MinNumberOfGoals = 0;
        private const int MaxNumberOfGoals = 6;

        private Random _random = new Random();

        private readonly IMatchRecordRepository _matchRecordRepository;

        public GroupMatchPerformer(IMatchRecordRepository matchRecordRepository)
        {
            _matchRecordRepository = matchRecordRepository;
        }

        public void PerformMatch(ITeamModel homeTeam, ITeamModel awayTeam)
        {
            int homeTeamGoals = _random.Next(MinNumberOfGoals, MaxNumberOfGoals);
            int awayTeamGoals = _random.Next(MinNumberOfGoals, MaxNumberOfGoals);

            DecideMatchResultBasedOnGoals(homeTeam, awayTeam, homeTeamGoals, awayTeamGoals);
        }

        private void DecideMatchResultBasedOnGoals(ITeamModel homeTeam, ITeamModel awayTeam, int homeTeamGoals,
            int awayTeamGoals)
        {
            IMatchResultStatus matchResultStatus = null;

            if (homeTeamGoals > awayTeamGoals)
            {
                matchResultStatus = new WinningMatchResult(homeTeam, awayTeam, homeTeamGoals, awayTeamGoals);
            }

            if (awayTeamGoals > homeTeamGoals)
            {
                matchResultStatus = new WinningMatchResult(awayTeam, homeTeam, awayTeamGoals, homeTeamGoals);
            }

            if (homeTeamGoals == awayTeamGoals)
            {
                matchResultStatus = new DrawMatchResult(homeTeam, awayTeam, homeTeamGoals);
            }

            AddMatchResultToRepository(homeTeam, awayTeam, matchResultStatus);
        }

        private void AddMatchResultToRepository(ITeamModel homeTeam, ITeamModel awayTeam, IMatchResultStatus matchResultStatus)
        {
            IMatchRecordModel matchRecord = new GroupMatchRecordModel(homeTeam, awayTeam, matchResultStatus);

            _matchRecordRepository.AddNewRecords(matchRecord);
        }
    }
}