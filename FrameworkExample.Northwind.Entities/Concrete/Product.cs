using FrameworkExample.Core.Entities;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Product : IEntity
    {
        public Product()
        {

        }

        public virtual int ProductID { get; set; }

        public virtual string ProductName { get; set; }

        public virtual int? SupplierID { get; set; }

        public virtual int? CategoryID { get; set; }

        public virtual string QuantityPerUnit { get; set; }

        public virtual decimal? UnitPrice { get; set; }

        public virtual short? UnitsInStock { get; set; }

        public virtual short? UnitsOnOrder { get; set; }

        public virtual short? ReorderLevel { get; set; }

        public virtual bool Discontinued { get; set; }


        public virtual Category Category { get; set; }

        public virtual ICollection<Order_Detail> Order_Details { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
