using System.Collections.Generic;

namespace BucketlistConsole
{
    public interface IBucketListRepository
    {
        List<BucketListItem> GetBucketLists();
        void SaveBucketListItem(BucketListItem bucketListItem);
    }
}