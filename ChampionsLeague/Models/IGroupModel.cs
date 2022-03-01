using System.Collections.Generic;

namespace SemihCelek.ChampionsLeague.Models
{
    public interface IGroupModel
    {
        char GetGroupName();
        List<ITeamModel> GetCompetingTeamsList();
    }
}