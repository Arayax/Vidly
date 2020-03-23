using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {

        public IEnumerable<MembershipType> membershipTypes { get; set; }

        public Customer customer { get; set; }
        public string Title
        {
            get
            {
                if (customer != null && customer.Id != 0)

                    return "Edit customer";

                return "New customer";
            }
        }
    }
}