namespace SemihCelek.ChampionsLeague.Models.PotGroups
{
    public class InitialTeamModel : IInitialTeamModel
    {
        private readonly string _teamName;
        private readonly string _teamCountryCode;
        private readonly int _teamSeedPoint;

        public InitialTeamModel(string teamName, string teamCountryCode, int teamSeedPoint)
        {
            _teamName = teamName;
            _teamCountryCode = teamCountryCode;
            _teamSeedPoint = teamSeedPoint;
        }
        
        public string GetTeamName()
        {
            return _teamName;
        }

        public string GetTeamCountryCode()
        {
            return _teamCountryCode;
        }

        public int GetSeedPoint()
        {
            return _teamSeedPoint;
        }
    }
}