using FrameworkExample.Core.Entities;
using System;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Order : IEntity
    {
        public Order()
        {

        }

        public virtual int OrderID { get; set; }

        public virtual string CustomerID { get; set; }

        public virtual int? EmployeeID { get; set; }

        public virtual DateTime? OrderDate { get; set; }

        public virtual DateTime? RequiredDate { get; set; }

        public virtual DateTime? ShippedDate { get; set; }

        public virtual int? ShipVia { get; set; }

        public virtual decimal? Freight { get; set; }

        public virtual string ShipName { get; set; }

        public virtual string ShipAddress { get; set; }

        public virtual string ShipCity { get; set; }

        public virtual string ShipRegion { get; set; }

        public virtual string ShipPostalCode { get; set; }

        public virtual string ShipCountry { get; set; }


        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Order_Detail> Order_Details { get; set; }

        public virtual Shipper Shipper { get; set; }
    }
}
