using System;
using System.Collections.Generic;
using System.Text;
using BucketlistConsole.Domain;

namespace BucketlistConsole.Repository
{
    class StatusRepository : IStatusRepository
    {
        private DataTable _table;

        public StatusRepository(DataTable dataTable)
        {
            this._table = dataTable;
        }

        public Status FindStatusByCode(string code)
        {
            return this._table.GetStatus(code);
        }

        public List<Status> GetStatuses()
        {
            return this._table.QueryStatus();
        }

        public void SaveStatus(Status status)
        {
            this._table.AddStatus(status);
        }
    }
}
