using FrameworkExample.Core.Entities;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Region : IEntity
    {
        public Region()
        {

        }

        public virtual int RegionID { get; set; }

        public virtual string RegionDescription { get; set; }


        public virtual ICollection<Territory> Territories { get; set; }
    }
}
