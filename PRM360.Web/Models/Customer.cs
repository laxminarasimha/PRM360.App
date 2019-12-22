using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM360.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string CompanyName { get; set; }

        public string Currency { get; set; }

        public string TimeZone { get; set; }

        public string Email { get; set; }

        public Int64 Phone { get; set; }

        public string GST { get; set; }
    }
}
