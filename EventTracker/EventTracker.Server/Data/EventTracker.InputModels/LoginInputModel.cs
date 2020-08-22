using System.ComponentModel.DataAnnotations;

namespace EventTracker.InputModels
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
