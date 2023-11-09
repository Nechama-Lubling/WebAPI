using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {





        private readonly Manager214877003Context _managerContext;
        public OrderRepository(Manager214877003Context managerContext)
        {
            _managerContext = managerContext;
        }

        public async Task<Order> addOrder(Order order)
        {

            await _managerContext.Orders.AddAsync(order);
            await _managerContext.SaveChangesAsync();
            return order;

        }



    }
}
