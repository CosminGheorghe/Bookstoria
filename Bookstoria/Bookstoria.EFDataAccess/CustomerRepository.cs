using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bookstoria.AplicationLogic.Abstractions;

namespace Bookstoria.EFDataAccess
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BookstoriaDbContext dbContext) : base(dbContext)
        {

        }

        public Customer GetCustomerByUserID(Guid id)
        {
            return dbContext.Customers
                            .Where(customer => customer.ID == id)
                            .SingleOrDefault();
        }

    }
}
