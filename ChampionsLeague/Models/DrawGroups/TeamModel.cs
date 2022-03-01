namespace SemihCelek.ChampionsLeague.Models.DrawGroups
{
    public class TeamModel : ITeamModel
    {
        private string _teamName;
        private string _teamCountryCode;
        private char _teamGroupName;
        private int _points;
        private int _goals;

        public TeamModel(string teamName, string teamCountryCode)
        {
            _teamName = teamName;
            _teamCountryCode = teamCountryCode;
        }


        public string GetTeamName()
        {
            throw new System.NotImplementedException();
        }

        public string GetTeamCountryCode()
        {
            throw new System.NotImplementedException();
        }

        public char GetGroup()
        {
            throw new System.NotImplementedException();
        }

        public int GetPoints()
        {
            throw new System.NotImplementedException();
        }

        public int GetGoals()
        {
            throw new System.NotImplementedException();
        }
    }
}