using System;
using System.Collections.Generic;
using System.Text;
using BucketlistConsole.Domain;

namespace BucketlistConsole.Repository
{
    interface IEventRepository
    {
        List<IEventAction> GetEventActions();
        void SaveEventAction(IEventAction eventAction);
    }
}
