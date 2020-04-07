using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Abstractions
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerByUserID(Guid userID);
    }
}
