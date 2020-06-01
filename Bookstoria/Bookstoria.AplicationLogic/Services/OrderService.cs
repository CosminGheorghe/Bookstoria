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
        
        public void CreateOrder(Customer customer, ICollection<Book> books, double price, int quantity)
        {
            orderRepository.Add(new Order
            {
                ID = Guid.NewGuid(),
                Customer = customer,
                Books = books,
                Price = price,
                Quantity = quantity
            });
        }

        public IEnumerable<Order> GetOrders(string customerId)
        {
            return orderRepository.GetAll().Where(customer => customer.Customer.ID == Guid.Parse(customerId));
        }
    }
}
