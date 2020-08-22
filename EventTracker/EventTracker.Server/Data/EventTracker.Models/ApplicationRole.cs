using EventTracker.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System;

namespace EventTracker.Models
{
    public class ApplicationRole : IdentityRole<int>, IAuditInfo
    {
        public ApplicationRole() : this(null)
        {
        }

        public ApplicationRole(string name) : base(name)
        {
        }

        public DateTime CreatedOn { get; set; }

        public DateTime EditedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
