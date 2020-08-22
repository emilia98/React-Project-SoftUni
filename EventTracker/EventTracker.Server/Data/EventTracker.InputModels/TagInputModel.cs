using System.ComponentModel.DataAnnotations;

namespace EventTracker.InputModels
{
    public class TagInputModel
    {
        [Required(ErrorMessage = "The name cannot be empty!")]
        [MinLength(2, ErrorMessage = "The name should contain at least 2 characters!")]
        [StringLength(30, ErrorMessage = "The name should be at most 30 characters!")]
        public string Name { get; set; }
    }
}
