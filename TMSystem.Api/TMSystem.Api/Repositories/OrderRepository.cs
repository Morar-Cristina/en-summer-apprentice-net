using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMSystem.Api.Models;
using TMSystem.Api.Exceptions;

namespace TMSystem.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TmsystemVsContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new TmsystemVsContext();
        }

        public async Task<Order> GetById(int id)
        {
            var @order = await _dbContext.Orders.Where(e => e.OrderId == id).FirstOrDefaultAsync();
            if (@order == null)
                throw new EntityNotFoundException(id, nameof(Order));

            return order;
        }
        

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;

            return orders;
        }

        public IEnumerable<Order> GetAllSortedByDateAndPrice()
        {
            var orders = _dbContext.Orders;
            var sortedOrders = orders.OrderBy(o => o.OrderedAt).ThenBy(o => o.TotalPrice);

            return sortedOrders;
        }

        /*public Order GetById(int id)
        {
            var @order = _dbContext.Orders.Where(e => e.OrderId == id).FirstOrDefault();

            return @order;
        }*/
        public int Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order @order)
        {
            _dbContext.Remove(@order);
            _dbContext.SaveChanges();
        }

        public void Update(Order @order)
        {
            _dbContext.Entry(@order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }

    
}
