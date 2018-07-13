using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly___Tutorial_MVC5.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        [ForeignKey(nameof(MembershipType))]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

    }
}