using Bookstoria.AplicationLogic.Abstractions;
using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bookstoria.AplicationLogic.Services
{
    public class CustomersServices
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IBookRepository bookRepository;

        public CustomersServices(ICustomerRepository customerRepository, IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.bookRepository = bookRepository;
        }

        public void RegisterCustomer(string id, string email, string firstName, string lastName, string phoneNumber, string city, string address)
        {
            Customer customer = new Customer()
            {
                ID = Guid.NewGuid(),
                UserID = Guid.Parse(id),
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                City = city,
                Email = email,
                Address = address
            };

            customerRepository.Add(customer);
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.GetAll().AsEnumerable();
        }
    }
}
