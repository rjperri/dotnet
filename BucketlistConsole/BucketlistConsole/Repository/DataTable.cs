using System.Collections.Generic;

namespace BucketlistConsole
{
    public class DataTable
    {
        private readonly List<BucketListItem> _BucketListItems;
        private int _NextBucketListItemId;

        public DataTable()
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