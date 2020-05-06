using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Model
{
    public class Admin
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
