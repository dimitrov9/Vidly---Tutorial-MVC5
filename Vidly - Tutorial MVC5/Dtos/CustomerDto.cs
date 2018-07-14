using System;
using System.ComponentModel.DataAnnotations;
using Vidly___Tutorial_MVC5.Models;

namespace Vidly___Tutorial_MVC5.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [DataType(DataType.Date)]
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}