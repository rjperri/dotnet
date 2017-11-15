using System;
using BucketlistConsole.Domain;
using ConsoleTables;

namespace BucketlistConsole
{
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
            var table = new ConsoleTable("ID", "NAME", "DESCRIPTION", "STATUS");

            this._bucketListRepository
                .GetBucketLists()
                .ForEach(delegate (BucketListItem bl)
                {
                    table.AddRow(bl.Id, bl.Name, bl.Description, bl.Status.Description);
                });
            table.Write(Format.Alternative);
            Console.WriteLine();
            return "ViewBucketList";
        }  
    }
}