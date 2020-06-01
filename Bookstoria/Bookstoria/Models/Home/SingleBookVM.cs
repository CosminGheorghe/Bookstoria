using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstoria.Models.Home
{
    public class SingleBookVM
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string ISBN { get; set; }
        public string ImageData { get; set; }
        public string CategoryType { get; set; }
        public double DiscountValue { get; set; }
    }
}
