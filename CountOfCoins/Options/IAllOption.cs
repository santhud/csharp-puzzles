using System.Collections.Generic;

namespace Options
{
    public interface IAllOption
    {
        Dictionary<Coin, int> GetMinCoinsForTheSum(int requiredSum, List<Coin> givenCoins);
    }
}