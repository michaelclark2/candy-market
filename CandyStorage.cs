﻿using System;
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
            new Candy() { Name = "Laffy Taffy", Flavor = "Fruity", Manufacturer = "Willy Wonka", ReceivedOn = DateTime.Now },
            new Candy() { Name = "Almond Joy", Flavor = "Chocolate", Manufacturer = "Hershey", ReceivedOn = DateTime.Now },
            new Candy() { Name = "Crunch Bar", Flavor = "Chocolate", Manufacturer = "Nestle", ReceivedOn = DateTime.Now },
            new Candy() { Name = "Peanut M&Ms", Flavor = "Nutty", Manufacturer = "Mars", ReceivedOn = DateTime.Now }
        }; 

        public List<Candy> GetSomeCandy()
        {
            var candies = new List<Candy>();
            for (var i = 0; i < 5; i++)
            {
                candies.Add(_candies[new Random().Next(0, _candies.Count)]);
            }
            return candies;
        }

        public IList<string> GetCandyTypes()
        {
            return _candies.Select(c => c.Flavor).Distinct().ToList();
        }

        internal void SaveNewCandy(Candy newCandy)
        {
            _candies.Add(newCandy);
        }

        public IList<string> GetCandyMakes()
        {
            return _candies.Select(c => c.Manufacturer).Distinct().ToList();
        }

        public IList<string> GetCandyNames()
        {
            return _candies.Select(c => c.Name).Distinct().ToList();
        }

        public IList<string> GetCandyNames(string candyType)
        {
            return _candies
                .Where(c => c.Flavor == candyType)
                .Select(c => c.Name)
                .Distinct()
                .ToList();
        }

        internal void EatCandy(string candyName)
        {
            var candies = _candies.Where(c => c.Name == candyName).ToList();
            var candy = candies.First(c => c.ReceivedOn == candies.Min(cc => cc.ReceivedOn));
            _candies.Remove(candy);
        }

        internal string EatRandomCandy(string candyType)
        {
            var candies = _candies
                .Where(c => c.Flavor == candyType)
                .Select(c => c.Name)
                .Distinct()
                .ToList();

            var candyToEat = candies[new Random().Next(0, candies.Count)];

            EatCandy(candyToEat);

            return candyToEat;
           
        }
    }
}