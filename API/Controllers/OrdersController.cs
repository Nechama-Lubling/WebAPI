using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {


        IOrderService _orderService;
        IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }   
        // GET: api/<OrdersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<OrdersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderDTO order)
        {

            Order newOrder = _mapper.Map<OrderDTO, Order>(order);
            OrderReturnDTO newOrderReturn = _mapper.Map<Order, OrderReturnDTO>(await _orderService.addOrder(newOrder));
            if (newOrderReturn == null)
            {
                return NoContent();
            }

           return Ok(newOrderReturn);

        }
    }
}
