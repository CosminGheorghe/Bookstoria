using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Model
{
    public class Order
    {
        public Guid ID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Book> Books { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
