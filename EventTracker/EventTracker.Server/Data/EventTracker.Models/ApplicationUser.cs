using EventTracker.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System;

namespace EventTracker.Models
{
    public class ApplicationUser : IdentityUser<int>, IAuditInfo
    {
        public ApplicationUser()
        {
        }

        public DateTime CreatedOn { get; set; }

        public DateTime EditedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
