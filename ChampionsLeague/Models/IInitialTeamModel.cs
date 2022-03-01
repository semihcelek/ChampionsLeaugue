namespace SemihCelek.ChampionsLeague.Models
{
    public interface IInitialTeamModel
    {
        string GetTeamName();
        string GetTeamCountryCode();
        int GetSeedPoint();
    }
}