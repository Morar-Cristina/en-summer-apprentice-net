using TMSystem.Api.Models;

namespace TMSystem.Api.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetAllSortedByDateAndPrice();

        Task<Order> GetById(int id);
        //Order GetById(int id);

        int Add(Order @order);

        void Update(Order @order);

        void Delete(Order @order);
    }
}
