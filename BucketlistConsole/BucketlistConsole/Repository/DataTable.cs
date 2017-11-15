using System.Collections.Generic;

namespace BucketlistConsole
{
    public class DataTable
    {
        private readonly List<BucketListItem> _BucketListItems;
        private readonly List<Status> _Status;
        private int _NextBucketListItemId;

        public DataTable()
        {
            this._BucketListItems = new List<BucketListItem>();
            this._Status = new List<Status>();
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

        public void AddStatus(Status status)
        {
            this._Status.Add(status);
        }

        public List<Status> QueryStatus()
        {
            return this._Status;
        }

        public Status GetStatus(string code)
        {
            return this._Status.Find(s => s.Code.Equals(code));
        }

    }
}