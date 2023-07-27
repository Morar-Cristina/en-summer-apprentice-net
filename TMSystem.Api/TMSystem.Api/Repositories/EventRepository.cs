using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMSystem.Api.Models;
using TMSystem.Api.Exceptions;

namespace TMSystem.Api.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TmsystemVsContext _dbContext;

        public EventRepository()
        {
            _dbContext = new TmsystemVsContext();
        }
        public async Task<Event> GetById(int id)
        {
            var @event = await _dbContext.Events.Where(e => e.EventId == id).FirstOrDefaultAsync();
            if (@event == null)
                throw new EntityNotFoundException(id, nameof(Event));

            return @event;
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;

            return events;
        }

        public Event GetByName(string name)
        {
            var @event = _dbContext.Events.Where(e => e.EventName == name).FirstOrDefault();

            return @event;
        }

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public void Delete(Event @event)
        {
            _dbContext.Remove(@event);
            _dbContext.SaveChanges();
        }

        public void Update(Event @event)
        {
            _dbContext.Entry(@event).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}