namespace SemihCelek.ChampionsLeague.Models.Matches
{
    public interface IMatchPerformer
    {
        void PerformMatch(ITeamModel homeTeam, ITeamModel awayTeam);
    }
}