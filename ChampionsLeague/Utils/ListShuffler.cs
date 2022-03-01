using System;
using System.Collections.Generic;

namespace SemihCelek.ChampionsLeague.Utils
{
    public static class ListShuffler
    {
        private static readonly Random Random = new Random();
        
        public static List<T> ShuffleList<T>(List<T> list)
        {
            list.Shuffler();
            return list;
        }

        private static void Shuffler<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}