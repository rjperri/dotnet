using System;
using BucketlistConsole.Domain;

namespace BucketlistConsole
{
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
}