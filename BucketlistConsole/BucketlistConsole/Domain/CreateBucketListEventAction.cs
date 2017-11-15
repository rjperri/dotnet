using System;
using System.Collections.Generic;
using System.Text;

namespace BucketlistConsole.Domain
{
    class CreateBucketListEventAction : IEventAction
    {
        private IBucketListRepository _BucketListRepository;
        private BucketListItem _BucketListItem;

        public CreateBucketListEventAction(IBucketListRepository bucketListRepository, BucketListItem bucketListItem)
        {
            this._BucketListRepository = bucketListRepository;
            this._BucketListItem = bucketListItem;
        }

        public void PerformAction()
        {
            this._BucketListRepository.SaveBucketListItem(this._BucketListItem);
        }
    }
}
