using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Model
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }

        string CreatedBy { get; set; }

        DateTime UpdatedOn { get; set; }

        string UpdatedBy { get; set; }

        string CreatProcess { get; set; }

        string ModifyProcess { get; set; }
    }
}
