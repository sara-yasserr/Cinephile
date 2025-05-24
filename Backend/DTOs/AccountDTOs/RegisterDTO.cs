using System.ComponentModel.DataAnnotations;

namespace CinephileProject.AccountDTOs
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }
        //
        [StringLength(100, MinimumLength = 6)]
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
        //
        //[Required(ErrorMessage = "Please confirm your password.")]
        //[Compare("Password", ErrorMessage = "Passwords do not match.")]
        //public string confirmPassword { get; set; }
        //
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
