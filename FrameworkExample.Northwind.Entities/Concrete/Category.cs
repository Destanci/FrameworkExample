using FrameworkExample.Core.Entities;
using System.Collections.Generic;

namespace FrameworkExample.Northwind.Entities.Concrete
{
    public partial class Category : IEntity
    {
        public Category()
        {

        }

        public virtual int CategoryID { get; set; }

        public virtual string CategoryName { get; set; }

        public virtual string Description { get; set; }

        public virtual byte[] Picture { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
