using System;
using System.Collections.Generic;
using System.Text;


namespace Bookstoria.AplicationLogic.Model
{
    public class Customer 
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
