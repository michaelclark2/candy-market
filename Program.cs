using System;
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
                if (userInput.Key == ConsoleKey.D1)
                {
                    AddNewCandy(db);
                    userInput = MainMenu(db);
                }
                if (userInput.Key == ConsoleKey.D2)
                {
                    EatCandy(db);
                    userInput = MainMenu(db);
                }

            }

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
                .AddMenuText("Press 0 to exit.");
            Console.Write(mainMenu.GetFullMenu());
            var userOption = Console.ReadKey();
            return userOption;
        }

        internal static void AddNewCandy(CandyStorage db)
        {
            var candyTypes = db.GetCandyTypes();
            var newCandyMenu = new View()
                .AddMenuText("What type of candy did you get?")
                .AddMenuOptions(candyTypes);
            Console.Write(newCandyMenu.GetFullMenu());

            var selectedCandyType = Console.ReadKey().KeyChar.ToString();
            var candyTypeIndex = int.Parse(selectedCandyType);
            var candyType = candyTypes[candyTypeIndex - 1];

            var candyNameMenu = new View()
                    .AddMenuText("What is the name of the candy?");
            Console.Write(candyNameMenu.GetFullMenu());

            var candyName = Console.ReadLine();


            var candyMakes = db.GetCandyMakes();
            var candyMakeMenu = new View()
                    .AddMenuText("Who makes the candy?")
                    .AddMenuOptions(candyMakes);

            Console.Write(candyMakeMenu.GetFullMenu());

            int candyMakeIndex;
            var candyMake = Console.ReadLine();
            int.TryParse(candyMake, out candyMakeIndex);

            if (candyMakeIndex > 0)
            {
                candyMake = candyMakes[candyMakeIndex - 1];
            }

            var candyToAdd = new Candy { Name = candyName, Flavor = candyType, Manufacturer = candyMake, ReceivedOn = DateTime.Now };

            db.SaveNewCandy(candyToAdd);
        }

        internal static void EatCandy(CandyStorage db)
        {
            throw new NotImplementedException();
        }
    }
}
