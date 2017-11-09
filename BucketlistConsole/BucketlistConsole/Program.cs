using System.Collections.Generic;
using System;
using System.Linq;

namespace BucketlistConsole
{

    public class Program
    {
        public static void Main()
        {
            Table table = new Table();
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


    public interface ICommand
    {
        string displayTitle();
        string execute();
    }


    public class CreateBucketlistItemCommand : ICommand
    {
        private IBucketListRepository _bucketListRepository;

        public CreateBucketlistItemCommand(IBucketListRepository bucketListRepository)
        {
            this._bucketListRepository = bucketListRepository;
        }

        public string displayTitle()
        {
            return "Create a New Bucket List Item";
        }

        public string execute()
        {
            BucketListItem bucketListItem = new BucketListItem();
            Console.WriteLine();
            Console.Write("Enter a BucketList Name: ");
            var name = Console.ReadLine();
            bucketListItem.Name = name;
            Console.Write("Enter a description for " + name + ": ");
            var description = Console.ReadLine();
            bucketListItem.Description = description;
            _bucketListRepository.SaveBucketListItem(bucketListItem);
            Console.WriteLine();
            Console.WriteLine(name + "...Saved");
            return "CreateNewBucketListItem";
        }
    }

    public class MainMenuCommand : ICommand
    {
        public string displayTitle()
        {
            return "Main Menu";
        }

        public string execute()
        {
            return "MainMenu";
        }
    }

    public class ViewBucketlistCommand : ICommand
    {
        private IBucketListRepository _bucketListRepository;

        public ViewBucketlistCommand(IBucketListRepository bucketListRepository)
        {
            this._bucketListRepository = bucketListRepository;
        }

        public string displayTitle()
        {
            return "View Bucket Lists";
        }

        public string execute()
        {
            Console.WriteLine();
            this._bucketListRepository
                .GetBucketLists()
                .ForEach(delegate (BucketListItem bl)
                {
                    Console.WriteLine(bl.Id + " : " + bl.Name + " - " + bl.Description);
                });
            return "ViewBucketList";
        }
    }

    public class Status
    {
        public string Code;
        public string Description;

        public Status(String Code)
        {
            this.Code = Code;
        }
    }

    public class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }


    public class BucketListItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public List<Task> Tasks;
    }

    public interface IBucketListRepository
    {
        List<BucketListItem> GetBucketLists();
        void SaveBucketListItem(BucketListItem bucketListItem);
    }

    public class BucketListRepository : IBucketListRepository
    {
        private Table _table;

        public BucketListRepository(Table table)
        {
            this._table = table;
        }

        public List<BucketListItem> GetBucketLists()
        {
            return _table.QueryBucketLists();
        }

        public void SaveBucketListItem(BucketListItem bucketListItem)
        {
            bucketListItem.Status = new Status("A");
            _table.AddBucketListItem(bucketListItem);
        }
    }

    public class Table
    {
        private readonly List<BucketListItem> _BucketListItems;
        private int _NextBucketListItemId;

        public Table()
        {
            this._BucketListItems = new List<BucketListItem>();
            this._NextBucketListItemId = 0;
        }

        public void AddBucketListItem(BucketListItem bucketListItem)
        {
            bucketListItem.Id = ++this._NextBucketListItemId;
            this._BucketListItems.Add(bucketListItem);
        }

        public List<BucketListItem> QueryBucketLists()
        {
            return this._BucketListItems;
        }

        public BucketListItem getBucketListItem(int Id)
        {
            return this._BucketListItems.Find(b => b.Id == Id);
        }

    }
}