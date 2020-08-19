using EventTracker.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace EventTracker.Models
{
    public class Tag : BaseModel<int>
    {
        [Required]
        [MinLength(2)]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(30)]
        public string NormalizedName { get; set; }
    }
}
