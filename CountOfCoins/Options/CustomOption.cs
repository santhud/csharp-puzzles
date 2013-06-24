using System;
using System.Collections.Generic;

namespace Options
{
    public class CustomOption : IAllOption
    {
        public Dictionary<Coin, int> GetMinCoinsForTheSum(int requiredSum, List<Coin> givenCoins)
        {
            var result = new Dictionary<Coin, int>();
            givenCoins.Sort((i, j) => (i < j) ? 1 : (i > j) ? -1 : 0);
            foreach (var coin in givenCoins)
            {
                var currCount = requiredSum / Convert.ToInt32(coin);
                result.Add(coin, currCount);
                if (requiredSum % Convert.ToInt32(coin) == 0)
                {
                    return result;
                }
                requiredSum -= (Convert.ToInt32(coin) * currCount);
            }
            return result;
        }
    }
}

