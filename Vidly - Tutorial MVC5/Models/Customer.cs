using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly___Tutorial_MVC5.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [ForeignKey(nameof(MembershipType))]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

    }
}