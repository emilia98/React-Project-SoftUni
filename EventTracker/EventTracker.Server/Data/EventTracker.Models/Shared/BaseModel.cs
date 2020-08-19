using System;
using System.ComponentModel.DataAnnotations;

namespace EventTracker.Models.Shared
{
    public abstract class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime EditedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
