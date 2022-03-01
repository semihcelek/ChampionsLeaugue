using System;
using System.IO;

namespace SemihCelek.ChampionsLeague.Utils
{
    public class TeamDataPathFinder : ITeamDataPathFinder
    {
        private readonly string _projectDirectory;

        public TeamDataPathFinder()
        {
            _projectDirectory = SetProjectDirectory();
        }
        private static string SetProjectDirectory()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            return projectDirectory;
        }

        public string GetTeamDataPath()
        {
            string dataPath =  $"{_projectDirectory}/team-data.txt";
            return dataPath;
        }
    }
}