using System;

namespace EventTracker.Models.Shared
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime EditedOn { get; set; }
    }
}
