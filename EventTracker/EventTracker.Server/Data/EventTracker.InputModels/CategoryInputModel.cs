using System.ComponentModel.DataAnnotations;

namespace EventTracker.InputModels
{
    public class CategoryInputModel
    {
        [Required]
        [MinLength(2)]
        [StringLength(45)]
        public string Name { get; set; }
    }
}
