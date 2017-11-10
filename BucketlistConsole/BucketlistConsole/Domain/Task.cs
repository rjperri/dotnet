namespace BucketlistConsole
{
    public class Task : IDomainObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }

        public string DisplayName()
        {
            return Name;
        }
    }
}