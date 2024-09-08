using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingFeature.DAL
{
    public abstract class BaseEntity
    {
        public virtual DateTime CreationTime { get; set; }
        public virtual Guid? CreatedBy { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual Guid? LastModifierId { get; set; }
        public virtual Guid? DeleterId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
    }
}
