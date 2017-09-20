using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Model
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public string CreatProcess { get; set; }

        public string ModifyProcess { get; set; }
    }
}
