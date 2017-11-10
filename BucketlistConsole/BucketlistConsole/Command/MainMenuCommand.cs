namespace BucketlistConsole
{
    public class MainMenuCommand : ICommand
    {
        public string displayTitle()
        {
            return "Main Menu";
        }

        public string execute()
        {
            return "MainMenu";
        }
    }
}