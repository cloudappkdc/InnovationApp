using System;
using System.Collections.Generic;
using System.Text;

namespace Template.DTO
{
    public abstract class AuditableDTO<T> : DTO<T>
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public string CreatProcess { get; set; }

        public string ModifyProcess { get; set; }
    }
}
