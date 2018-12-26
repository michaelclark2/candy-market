using System;
using System.Collections.Generic;
using System.Linq;

namespace candy_market
{
    internal class CandyStorage
    {
        static List<Candy> _candies = new List<Candy>()
        {
            new Candy() { Name = "Wonka Bar", Manufacturer = "Willy Wonka", Flavor = "Chocolate", ReceivedOn = DateTime.Now.AddDays(3) },
            new Candy() { Name = "Everlasting Gobstopper", Manufacturer = "Willy Wonka", Flavor = "Fruity", ReceivedOn = DateTime.Now.AddDays(2) },
            new Candy() { Name = "Twizzlers", Manufacturer = "Hershey", Flavor = "Fruity", ReceivedOn = DateTime.Now.AddDays(1) },
            new Candy() { Name = "Mr. Goodbar", Manufacturer = "Hershey", Flavor = "Nutty", ReceivedOn = DateTime.Now.AddDays(0) },
            new Candy() { Name = "Reese's", Manufacturer = "Hershey", Flavor = "Nutty", ReceivedOn = DateTime.Now.AddDays(3) },
            new Candy() { Name = "Twix", Manufacturer = "Mars", Flavor = "Chocolate", ReceivedOn = DateTime.Now.AddDays(3) },
            new Candy() { Name = "M&Ms", Manufacturer = "Mars", Flavor = "Chocolate", ReceivedOn = DateTime.Now.AddDays(1) },
            new Candy() { Name = "PayDay", Manufacturer = "Mars", Flavor = "Nutty", ReceivedOn = DateTime.Now.AddDays(1) },
            new Candy() { Name = "Skittles", Manufacturer = "Mars", Flavor = "Fruity", ReceivedOn = DateTime.Now.AddDays(0) },
        }; 

        public IList<string> GetCandyTypes()
        {
            return _candies.Select(c => c.Flavor).Distinct().ToList();
        }

        internal void SaveNewCandy(ConsoleKey key)
        {
            throw new NotImplementedException();
        }
    }
}