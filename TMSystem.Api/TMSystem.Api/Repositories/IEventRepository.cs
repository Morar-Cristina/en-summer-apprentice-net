using TMSystem.Api.Models;

namespace TMSystem.Api.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Task<Event> GetById(int id);

        int Add(Event @event);

        void Update(Event @event);

        int Delete(int id);
    }
}