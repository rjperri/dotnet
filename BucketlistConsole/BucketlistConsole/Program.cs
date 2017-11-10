using System.Collections.Generic;
using System;
using System.Linq;

namespace BucketlistConsole
{

    public class Program
    {
        public static void Main()
        {
            //TODO: Create some predefined BuckelistItems with different statuses 
            //TODO: Make statuses in its own table, during bucketlist save, query for status and then add to bucket list <-- more of the "FIG WAY"
            DataTable table = new DataTable();
            BucketListRepository bucketListRepository = new BucketListRepository(table);
            List<ICommand> mainMenu = new List<ICommand>();

            MainMenuCommand mainMenuCommand = new MainMenuCommand();
            ViewBucketlistCommand viewBucketlistCommand = new ViewBucketlistCommand(bucketListRepository);
            CreateBucketlistItemCommand createNewBucketlistItem = new CreateBucketlistItemCommand(bucketListRepository);

            mainMenu.Add(viewBucketlistCommand);
            mainMenu.Add(createNewBucketlistItem);

            Dictionary<ICommand, List<ICommand>> menu = new Dictionary<ICommand, List<ICommand>>();

            menu.Add(mainMenuCommand, mainMenu);
            int input;
            do
            {
                Console.Clear();
                DisplayTitle(bucketListRepository.GetBucketLists().Count());
                Console.Write(mainMenuCommand.displayTitle());
                Console.Write(" : ");
                List<ICommand> commands = menu[mainMenuCommand];
                Console.Write(String.Join(", ", commands.Select(c => commands.IndexOf(c) + " = " + c.displayTitle())) + ", -999 = EXIT");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("What do you want to do? ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input != -999)
                {
                    ICommand command = menu[mainMenuCommand][input];
                    Console.Clear();
                    DisplayTitle(bucketListRepository.GetBucketLists().Count());
                    Console.WriteLine(command.displayTitle());
                    command.execute();
                    Console.WriteLine();
                    Console.Write("Press enter to continue ... ");
                    Console.ReadLine();
                }
                Console.Clear();
            } while (input != -999);

            Console.WriteLine("Bye! Thanks for using and reach for them goals!");

        }

        public static void DisplayTitle(int bucketListCount)
        {
            Console.WriteLine("Bucket List Completor");
            Console.WriteLine("You have " + bucketListCount + " Bucket Lists");
            Console.WriteLine("--------------------------------------------------");
        }

    }
}