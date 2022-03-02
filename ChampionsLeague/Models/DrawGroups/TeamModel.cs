namespace SemihCelek.ChampionsLeague.Models.DrawGroups
{
    public class TeamModel : ITeamModel
    {
        private string _teamName;
        private string _teamCountryCode;
        private int _points;
        private int _goals;

        public TeamModel(string teamName, string teamCountryCode)
        {
            _teamName = teamName;
            _teamCountryCode = teamCountryCode;
            SetupTeam();
        }

        private void SetupTeam()
        {
            _goals = 0;
            _points = 0;
        }

        public string GetTeamName()
        {
            return _teamName;
        }

        public string GetTeamCountryCode()
        {
            return _teamCountryCode;
        }

        public int GetPoints()
        {
            return _points;
        }

        public int GetGoals()
        {
            return _goals;
        }

        public void AddPoints(int point)
        {
            _points += point;
        }

        public void AddGoals(int goals)
        {
            _goals += goals;
        }
    }
}