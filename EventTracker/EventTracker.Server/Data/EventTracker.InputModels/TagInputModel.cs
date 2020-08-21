using System.ComponentModel.DataAnnotations;

namespace EventTracker.InputModels
{
    public class TagInputModel
    {
        [Required]
        [MinLength(2)]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
