using System;
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

            TeamPotAdjuster teamPotAdjuster = new TeamPotAdjuster(initialTeamModelRepository, potRepository);

        }
    }
}