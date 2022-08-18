using FrameworkExample.Core.Entities;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Territory : IEntity
    {
        public Territory()
        {

        }

        public virtual string TerritoryID { get; set; }

        public virtual string TerritoryDescription { get; set; }

        public virtual int RegionID { get; set; }


        public virtual Region Region { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
