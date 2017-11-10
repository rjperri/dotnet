namespace BucketlistConsole
{
    public class CommandEvent
    {
        public int Id { get; set; }
        public ICommand Command { get; set; }
        public IAction Action { get; set; }
        public IDomainObject DomainObject { get; set; }
    }
}