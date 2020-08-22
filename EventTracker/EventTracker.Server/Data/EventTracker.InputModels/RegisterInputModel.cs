using System.ComponentModel.DataAnnotations;

namespace EventTracker.InputModels
{
    public class RegisterInputModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(2, ErrorMessage = "The password should be at least 2 characters.")]
        public string Password { get; set; }
    }
}
