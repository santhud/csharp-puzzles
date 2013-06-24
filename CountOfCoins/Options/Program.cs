using System;
using System.Collections.Generic;

namespace Options
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int requiredSum = 4;
            var givenCoins = new List<Coin>
                                 {
                                     Coin.One, Coin.Three, Coin.Five, Coin.Two
                                 };

            var optionA = new CustomOption();
            var items = optionA.GetMinCoinsForTheSum(requiredSum, givenCoins);



            Console.WriteLine("Input :: {0}\r\nResult :: ", requiredSum);
            foreach (var item in items)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }
    }
}
