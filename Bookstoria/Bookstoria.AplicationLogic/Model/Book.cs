using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Model
{
    public class Book
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string ISBN { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
        public Discount Discount { get; set; }
    }
}
