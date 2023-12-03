using AutoMapper;
using DTO;
using Entities;
using Microsoft.Extensions.Logging;
using NLog;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {


        IMapper _mapper;

        private readonly ILogger<IOrderService> _logger;

        public IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository, IMapper mapper, ILogger<IOrderService> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Order> addOrder(Order order)
        {
            {
                int result = await checkOrderSum(order);
                if (result == 0)
                {
                    return await _orderRepository.addOrder(order);
                }
                order.OrderSum = result;

                return await _orderRepository.addOrder(order);
            }
        }

        private async Task<int> checkOrderSum(Order order)
        {
            int sum = 0;
            IEnumerable<OrderItem> items = order.OrderItems;
         
            foreach (var i in items)
            {
                sum += await _orderRepository.getPrice(i);
            }

            if (sum != order.OrderSum)
            {
                _logger.LogError($" error order sum {order.UserId}tried steelng");
                return sum;
            }
            return 0;

            
        }

    }

}

