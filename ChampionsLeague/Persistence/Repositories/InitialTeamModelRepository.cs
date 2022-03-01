using System;
using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;
using SemihCelek.ChampionsLeague.Models.PotGroups;

namespace SemihCelek.ChampionsLeague.Persistence.Repositories
{
    public class InitialTeamModelRepository : IInitialTeamModelRepository
    {
        private readonly IStorageContext _context;

        public InitialTeamModelRepository(IStorageContext context)
        {
            _context = context;
        }

        public List<IInitialTeamModel> GetAllTeams()
        {
            List<string> teamDataLines = _context.ReadAllLines();
            
            List<IInitialTeamModel> teamList = CreateInitialTeamModelsByParsingLines(teamDataLines);

            return teamList;
        }

        private List<IInitialTeamModel> CreateInitialTeamModelsByParsingLines(List<string> teamDataLines)
        {
            List<IInitialTeamModel> teamList = new List<IInitialTeamModel>();

            for (int i = 0; i < teamDataLines.Count; i++)
            {
                string[] spaceSeparatedTeamData = teamDataLines[i].Split(" ");

                IInitialTeamModel team = new InitialTeamModel(spaceSeparatedTeamData[0], spaceSeparatedTeamData[1],
                    Int32.Parse(spaceSeparatedTeamData[2]));

                teamList.Add(team);
            }

            return teamList;
        }
    }
}