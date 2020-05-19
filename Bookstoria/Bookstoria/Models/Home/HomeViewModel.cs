using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstoria.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
