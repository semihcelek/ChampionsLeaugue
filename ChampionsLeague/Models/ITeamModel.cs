namespace SemihCelek.ChampionsLeague.Models
{
    public interface ITeamModel
    {
        string GetTeamName();
        string GetTeamCountryCode();
        char GetGroup();
        int GetPoints();
        int GetGoals();
    }
}