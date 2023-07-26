using TMSystem.Api.Models;

namespace TMSystem.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TmsystemVsContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new TmsystemVsContext();
        }

        public int Add(Order order)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
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

        public Order GetById(int id)
        {
            var @order = _dbContext.Orders.Where(e => e.OrderId == id).FirstOrDefault();

            return @order;
        }

        public void Update(Order @order)
        {
            throw new NotImplementedException();
        }

    }

    
}
