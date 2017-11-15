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
            return this._table.QueryBucketLists();
        }

        public void SaveBucketListItem(BucketListItem bucketListItem)
        {
            bucketListItem.Status = new Status{Code = "C", Description = "Created"};
           this. _table.AddBucketListItem(bucketListItem);
        }

        public BucketListItem FindBucketListItemById(int id)
        {
            return this._table.getBucketListItem(id);
        }
    }
}