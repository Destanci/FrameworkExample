using FluentNHibernate.Mapping;
using FrameworkExample.Northwind.Entities.Concrete;

namespace FrameworkExample.Northwind.DataAccess.Concrete.NHibernate.Mapping
{
    class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();

            Id(x => x.CategoryID).Column("CategoryID");

            Map(x => x.CategoryName).Column("CategoryName");
            Map(x => x.Description).Column("Description");
            Map(x => x.Picture).Column("Picture");
        }
    }
}
