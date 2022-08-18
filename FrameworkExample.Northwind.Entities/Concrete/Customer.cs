using FrameworkExample.Core.Entities;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Customer : IEntity
    {
        public Customer()
        {

        }

        public virtual string CustomerID { get; set; }

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


        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<CustomerDemographic> CustomerDemographics { get; set; }
    }
}
