using Bookstoria.AplicationLogic.Abstractions;
using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstoria.AplicationLogic.Services
{
    public class OrderService
    {
        IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetOrders(string customerId)
        {
            return orderRepository.GetAll().Where(customer => customer.Customer.ID == Guid.Parse(customerId));
        }
    }
}
