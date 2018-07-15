using System.ComponentModel.DataAnnotations;

namespace Vidly___Tutorial_MVC5.View_Models.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}