using System;
using System.Collections.Generic;
using System.Linq;

namespace candy_market
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SetupNewApp();
            var userInput = MainMenu(db);

            while (userInput.Key != ConsoleKey.D0)
            {
                userInput = MainMenu(db);
                if (userInput.Key == ConsoleKey.D1)
                {
                    AddNewCandy(db);
                }
                if (userInput.Key == ConsoleKey.D2)
                {
                    var eatCandyMenu = new View()
                        .AddMenuOption("Eat some candy from your collection.")
                        .AddMenuOption("Eat a random candy.");
                    Console.Write(eatCandyMenu.GetFullMenu());

                    int selection;
                    var key = Console.ReadKey().KeyChar.ToString();
                    int.TryParse(key, out selection);
                    if (selection == 1)
                    {
                        EatCandy(db);
                    }
                    else if (selection == 2)
                    {
                        EatRandomCandy(db);
                        Console.ReadKey();
                    }
                }

                if (userInput.Key == ConsoleKey.D3)
                {

                    TradeCandy(db);
                   
                }

            }

        }

        private static void TradeCandy(CandyStorage db)
        {
            var you = new CandyUser("You");
            you.Candies = db.GetSomeCandy();

            var otherUsers = new List<CandyUser>()
            {
                new CandyUser("Greg"),
                new CandyUser("Charlene"),
                new CandyUser("Timmy"),
                new CandyUser("Madeline")

            };
            
            foreach(var user in otherUsers)
            {
                user.Candies = db.GetSomeCandy();
            }

            var tradeCandyMenu = new View()
                .AddMenuText("Choose a trade request")
                .AddMenuOptions(otherUsers.Select(u => u.WantsToTrade()).ToList());
            Console.Write(tradeCandyMenu.GetFullMenu());

            var chosenUser = Console.ReadKey().KeyChar.ToString();
            var chosenIndex = int.Parse(chosenUser);
            var otherUser = otherUsers[chosenIndex - 1];

            var userCandyMenu = new View()
                .AddMenuText($"Request a candy from {otherUser.Name}")
                .AddMenuOptions(otherUser.Candies.Select(c => c.Name).ToList());
            Console.Write(userCandyMenu.GetFullMenu());

            var chosenCandy = Console.ReadKey();


        }

        internal static CandyStorage SetupNewApp()
        {
            Console.Title = "Cross Confectioneries Incorporated";

            var db = new CandyStorage();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            return db;
        }

        internal static ConsoleKeyInfo MainMenu(CandyStorage db)
        {
            View mainMenu = new View()
                .AddMenuOption("Did you just get some new candy? Add it here.")
                .AddMenuOption("Do you want to eat some candy? Take it here.")
                .AddMenuOption("Do you want to trade some candy? Do it here.")
                .AddMenuText("Press 0 to exit.");
            Console.Write(mainMenu.GetFullMenu());
            var userOption = Console.ReadKey();
            return userOption;
        }

        internal static void AddNewCandy(CandyStorage db)
        {

            // Get candy type
            var candyTypes = db.GetCandyTypes();
            var newCandyMenu = new View()
                .AddMenuText("What type of candy did you get?")
                .AddMenuOptions(candyTypes);
            Console.Write(newCandyMenu.GetFullMenu());

            var selectedCandyType = Console.ReadKey().KeyChar.ToString();
            var candyTypeIndex = int.Parse(selectedCandyType);
            var candyType = candyTypes[candyTypeIndex - 1];

            // Get candy name

            var candyNames = db.GetCandyNames(candyType);
            var candyNameMenu = new View()
                    .AddMenuText("What is the name of the candy?")
                    .AddMenuOptions(candyNames)
                    .AddMenuText("Or enter a new name");
            Console.Write(candyNameMenu.GetFullMenu());

            int candyNameIndex;
            var candyName = Console.ReadLine();
            int.TryParse(candyName, out candyNameIndex);

            if (candyNameIndex > 0)
            {
                candyName = candyNames[candyNameIndex - 1];
            }

            // Get candy manufacturer
            var candyMakes = db.GetCandyMakes();
            var candyMakeMenu = new View()
                    .AddMenuText("Who makes the candy?")
                    .AddMenuOptions(candyMakes)
                    .AddMenuText("Or enter a new manufacturer");

            Console.Write(candyMakeMenu.GetFullMenu());

            int candyMakeIndex;
            var candyMake = Console.ReadLine();
            int.TryParse(candyMake, out candyMakeIndex);

            if (candyMakeIndex > 0)
            {
                candyMake = candyMakes[candyMakeIndex - 1];
            }

            // Make new candy from inputs and save
            var candyToAdd = new Candy { Name = candyName, Flavor = candyType, Manufacturer = candyMake, ReceivedOn = DateTime.Now };

            db.SaveNewCandy(candyToAdd);
        }

        internal static void EatCandy(CandyStorage db)
        {
            var candyNames = db.GetCandyNames();
            var eatCandyMenu = new View()
                .AddMenuText("Which candy do you want to eat?")
                .AddMenuOptions(candyNames);

            Console.Write(eatCandyMenu.GetFullMenu());

            var candySelected = Console.ReadKey().KeyChar.ToString();
            var candyIndex = int.Parse(candySelected);
            var candyToEat = candyNames[candyIndex - 1];
            db.EatCandy(candyToEat);
        }
        internal static void EatRandomCandy(CandyStorage db)
        {
            var candyTypes = db.GetCandyTypes();
            var candyTypeMenu = new View()
                .AddMenuText("What kind of candy do you want to eat?")
                .AddMenuOptions(candyTypes);
            Console.Write(candyTypeMenu.GetFullMenu());

            var candySelected = Console.ReadKey().KeyChar.ToString();
            var candyIndex = int.Parse(candySelected);
            var candyType = candyTypes[candyIndex - 1];
            var candyEaten = db.EatRandomCandy(candyType);

            Console.WriteLine();
            Console.WriteLine($"You have eaten a {candyEaten}.");
        }
    }
}
