using TMSystem.Api.Models;

namespace TMSystem.Api.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Event GetById(long id);

        int Add(Event @event);

        void Update(Event @event);

        int Delete(long id);
    }
}