namespace BucketlistConsole
{
    public class Status : IDomainObject
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public string DisplayName()
        {
            return Description;
        }
    }
}