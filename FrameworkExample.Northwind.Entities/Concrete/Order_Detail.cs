using FrameworkExample.Core.Entities;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Order_Detail : IEntity
    {
        public virtual int OrderID { get; set; }

        public virtual int ProductID { get; set; }

        public virtual decimal UnitPrice { get; set; }

        public virtual short Quantity { get; set; }

        public virtual float Discount { get; set; }


        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
