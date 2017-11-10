using System.Collections.Generic;

namespace BucketlistConsole
{
    public class EventTable
    {
        private readonly List<CommandEvent> _CommandEvents;

        public EventTable()
        {
            this._CommandEvents = new List<CommandEvent>();
        }
        
        public void AddCommandEvent(CommandEvent commandEvent)
        {
            this._CommandEvents.Add(commandEvent);
        }

        public List<CommandEvent> QueryCommandEvents()
        {
            return this._CommandEvents;
        }

        public CommandEvent GetCommandEvent(int Id)
        {
            return this._CommandEvents.Find(ce => ce.Id == Id);
        }
    }
}