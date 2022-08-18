using FrameworkExample.Core.Entities;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Supplier : IEntity
    {
        public Supplier()
        {

        }

        public virtual int SupplierID { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual string ContactName { get; set; }

        public virtual string ContactTitle { get; set; }

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string Region { get; set; }

        public virtual string PostalCode { get; set; }

        public virtual string Country { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Fax { get; set; }

        public virtual string HomePage { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
