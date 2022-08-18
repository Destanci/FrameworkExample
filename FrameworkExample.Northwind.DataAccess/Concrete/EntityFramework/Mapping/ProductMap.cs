using FrameworkExample.Northwind.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace FrameworkExample.Northwind.DataAccess.Concrete.EntityFramework.Mapping
{
    class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(x => x.ProductID);
            Property(x => x.ProductID).HasColumnName("ProductID");

            Property(x => x.ProductName).HasColumnName("ProductName")
                .IsRequired()
                .HasMaxLength(40);
            Property(x => x.SupplierID).HasColumnName("SupplierID");
            Property(x => x.CategoryID).HasColumnName("CategoryID");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit")
                .HasMaxLength(20);
            Property(x => x.UnitPrice).HasColumnName("UnitPrice")
                .HasPrecision(19, 4)
                .HasColumnType("money");
            Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");
            Property(x => x.UnitsOnOrder).HasColumnName("UnitsOnOrder");
            Property(x => x.ReorderLevel).HasColumnName("ReorderLevel");
            Property(x => x.Discontinued).HasColumnName("Discontinued");

            HasRequired(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID);
            HasRequired(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SupplierID);

            HasMany(e => e.Order_Details)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
