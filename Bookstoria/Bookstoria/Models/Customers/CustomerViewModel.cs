using System;
using Bookstoria.AplicationLogic.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstoria.Models.Customers
{
    public class CustomerViewModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
