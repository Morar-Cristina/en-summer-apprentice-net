using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMSystem.Api.Models.Dto;
using TMSystem.Api.Repositories;

namespace TMSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var dtoOrders = orders.Select(o => new OrderDto()
            {
                OrderId = o.OrderId,
                OrderedAt = o.OrderedAt,
                NumberOfTickets = o.NumberOfTickets,
                TotalPrice = o.TotalPrice
            });
            return Ok(dtoOrders);
        }

        [HttpGet]
        public ActionResult<OrderDto> GetById(int id)
        {
            var @order = _orderRepository.GetById(id);

            if(order == null)
            {
                return NotFound();
            }

            var dtoOrder = new OrderDto()
            {
                OrderId = @order.OrderId,
                OrderedAt = @order.OrderedAt,
                NumberOfTickets = @order.NumberOfTickets,
                TotalPrice = @order.TotalPrice
            };
            return Ok(dtoOrder);
        }
    }
}
