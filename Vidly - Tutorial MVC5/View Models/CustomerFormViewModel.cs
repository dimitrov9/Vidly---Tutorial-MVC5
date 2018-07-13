using System.Collections.Generic;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5.View_Models
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}