namespace BucketlistConsole
{
    public interface ICommand
    {
        string displayTitle();
        string execute();
    }
}