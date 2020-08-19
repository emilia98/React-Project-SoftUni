using EventTracker.Models.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventTracker.Models
{
    public class Category : BaseModel<int>
    {
        [Required]
        [MinLength(2)]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(45)]
        public string NormalizedName { get; set; }

        public bool IsActive { get; set; }
    }
}
