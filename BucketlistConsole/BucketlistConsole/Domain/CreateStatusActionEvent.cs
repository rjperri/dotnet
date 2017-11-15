using System;
using System.Collections.Generic;
using System.Text;

namespace BucketlistConsole.Domain
{
    class CreateStatusEventAction : IEventAction
    {
        private IBucketListRepository _BucketListRepository;
        private Status _Status;

        public CreateStatusEventAction(IBucketListRepository BucketListRepository, Status Status)
        {
            this._BucketListRepository = BucketListRepository;
            this._Status = Status;
        }

        public void PerformAction()
        {
            throw new NotImplementedException();
        }
    }
}
