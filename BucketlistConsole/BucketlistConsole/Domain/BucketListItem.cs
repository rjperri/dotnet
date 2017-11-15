using System.Collections.Generic;

namespace BucketlistConsole.Domain
{
    public class BucketListItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public List<Task> Tasks;
    }
}