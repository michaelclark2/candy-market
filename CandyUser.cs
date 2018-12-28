using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace candy_market
{
    class CandyUser
    {
        public string Name { get; set; }
        public List<Candy> Candies { get; set; }

        public CandyUser(string name)
        {
            Name = name;
        }

        public Candy TradeCandy(Candy otherCandy, int chosenCandy)
        {

            var candyToTrade = Candies[chosenCandy];
            Candies.Remove(candyToTrade);
            Candies.Add(otherCandy);
            return candyToTrade;
        }

    }
}
