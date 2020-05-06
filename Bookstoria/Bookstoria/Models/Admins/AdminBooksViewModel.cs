using System;
using Bookstoria.AplicationLogic.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstoria.Models.Admins
{
    public class AdminBooksViewModel
    {
        public Admin Admin { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
