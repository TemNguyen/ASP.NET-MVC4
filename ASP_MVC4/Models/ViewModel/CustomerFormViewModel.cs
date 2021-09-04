using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC4.Models.ViewModel
{
    public class CustomerFormViewModel
    {
        public ICollection<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}