using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TMSystem.Api.Models.Dto;
using TMSystem.Api.Repositories;
using AutoMapper;


namespace TMSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
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
        /*
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
                }*/


        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var @order = await _orderRepository.GetById(id);

            if (@order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(@order);

            return Ok(orderDto);
        }


        [HttpGet]
        public ActionResult<List<OrderDto>> GetAllSortedByDateAndPrice()
        {
            var orders = _orderRepository.GetAllSortedByDateAndPrice();

            var dtoOrders = orders.Select(e => new OrderDto()
            {
                OrderId = e.OrderId,
                OrderedAt = e.OrderedAt,
                NumberOfTickets = e.NumberOfTickets,
                TotalPrice = e.TotalPrice
            });
            return Ok(dtoOrders);
        }


        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            if (orderEntity == null)
            {
                return NotFound();
            }
            if (orderPatch.TicketCategoryId != 0) orderEntity.TicketCategoryId = orderPatch.TicketCategoryId;
            if (orderPatch.NumberOfTickets != 0) orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            _orderRepository.Update(orderEntity);
            return NoContent();
        }

        
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }
    }
}
