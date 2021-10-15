using System;

namespace NoteBookApp.Logic.Domain
{
    public class Note:NHBase
    {
        public virtual string? Content { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}