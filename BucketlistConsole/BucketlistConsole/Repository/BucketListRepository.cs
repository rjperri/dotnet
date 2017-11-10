using System.Collections.Generic;

namespace BucketlistConsole
{
    public class BucketListRepository : IBucketListRepository
    {
        private DataTable _table;

        public BucketListRepository(DataTable table)
        {
            this._table = table;
        }

        public List<BucketListItem> GetBucketLists()
        {
            return _table.QueryBucketLists();
        }

        public void SaveBucketListItem(BucketListItem bucketListItem)
        {
            bucketListItem.Status = new Status{Code = "C", Description = "Created"};
            _table.AddBucketListItem(bucketListItem);
        }
    }
}