using FrameworkExample.Core.Entities;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class CustomerDemographic : IEntity
    {
        public CustomerDemographic()
        {

        }

        public virtual string CustomerTypeID { get; set; }

        public virtual string CustomerDesc { get; set; }


        public virtual ICollection<Customer> Customers { get; set; }
    }
}
