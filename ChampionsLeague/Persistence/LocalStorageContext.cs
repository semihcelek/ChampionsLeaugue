using System.Collections.Generic;
using System.IO;
using SemihCelek.ChampionsLeague.Utils;

namespace SemihCelek.ChampionsLeague.Persistence
{
    public class LocalStorageContext : IStorageContext
    {
        private readonly ITeamDataPathFinder _dataPathFinder;

        public LocalStorageContext(ITeamDataPathFinder dataPathFinder)
        {
            _dataPathFinder = dataPathFinder;
        }

        public List<string> ReadAllLines()
        {
            List<string> lines = new List<string>();
            string[] readLines = File.ReadAllLines(_dataPathFinder.GetTeamDataPath());

            for (int i = 0; i < readLines.Length; i++)
            {
                lines.Add(readLines[i]);
            }

            return lines;
        }
    }
}