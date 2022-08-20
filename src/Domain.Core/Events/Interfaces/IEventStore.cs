using NetDevPack.Messaging;

namespace Domain.Core.Events.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
