using FrameworkExample.Core.Entities;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Shipper : IEntity
    {
        public Shipper()
        {

        }

        public virtual int ShipperID { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual string Phone { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
