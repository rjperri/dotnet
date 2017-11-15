using System;
using System.Collections.Generic;
using System.Text;
using BucketlistConsole.Domain;

namespace BucketlistConsole.Repository
{
    interface IStatusRepository
    {
        List<Status> GetStatuses();
        void SaveStatus(Status status);
        Status FindStatusByCode(string code);
    }
}
