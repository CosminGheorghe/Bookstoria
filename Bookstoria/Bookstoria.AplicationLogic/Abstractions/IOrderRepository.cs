using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Abstractions
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetOrderByCustomer(Customer customer);
        Order GetOrderByID(string orderID);
        ICollection<Book> GetBooksFromOrder(string orderID);
        double GetOrderPrice(string orderID);
        double GetOrderQuantity(string orderID);
    }
}
