using System.Collections.Generic;
using SemihCelek.ChampionsLeague.Models;

namespace SemihCelek.ChampionsLeague.Persistence.Repositories
{
    public interface IInitialTeamModelRepository
    {
        List<IInitialTeamModel> GetAllTeams();
    }
}