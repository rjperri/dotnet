using System;
using System.Collections.Generic;
using System.Text;

namespace BucketlistConsole.Command
{
    class CreateBucketListItemAction : IAction
    {
        private BucketListRepository _BucketListRepository { get; set; }
        public BucketListItem BucketListItem { get; set; }

        public void PerformAction()
        {
            this._BucketListRepository.SaveBucketListItem(this.BucketListItem);
        }
    }
}
