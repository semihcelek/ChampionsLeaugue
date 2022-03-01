using System.Collections.Generic;

namespace SemihCelek.ChampionsLeague.Persistence
{
    public interface IStorageContext
    {
        List<string> ReadAllLines();
    }
}