using EventTracker.Models.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventTracker.Models
{
    public class Event : BaseModel<int>
    {
        [Required]
        [MinLength(2)]
        [StringLength(70)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(70)]
        public string NormalizedName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
