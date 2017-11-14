using System;
using System.Collections.Generic;
using System.Text;

namespace BucketlistConsole.Domain
{
    class CreateBucketListEventAction : IEventAction
    {
        private IBucketListRepository _BucketListRepository;
        private BucketListItem _BucketListItem;

        public void PerformAction()
        {
            this._BucketListRepository.SaveBucketListItem(this._BucketListItem);
        }
    }
}
