using System.Collections.Generic;

namespace BucketlistConsole
{
    public class BucketListItem : IDomainObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public List<Task> Tasks;

        public string DisplayName()
        {
            return Name;
        }
    }
}