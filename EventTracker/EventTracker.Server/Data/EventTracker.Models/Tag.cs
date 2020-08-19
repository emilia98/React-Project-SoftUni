using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventTracker.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(30)]
        public string NormalizedName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime EditedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
