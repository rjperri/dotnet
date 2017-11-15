using System.Collections.Generic;
using BucketlistConsole.Domain;

namespace BucketlistConsole
{
    public interface IBucketListRepository
    {
        List<BucketListItem> GetBucketLists();
        void SaveBucketListItem(BucketListItem bucketListItem);
        BucketListItem FindBucketListItemById(int id);
    }
}