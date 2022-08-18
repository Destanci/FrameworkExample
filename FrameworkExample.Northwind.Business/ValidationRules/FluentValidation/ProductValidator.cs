using FluentValidation;
using FrameworkExample.Northwind.Entities.Concrete;

namespace FrameworkExample.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //RuleFor(x => x.ProductID).NotEmpty();
            //RuleFor(x => x.CategoryID).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.QuantityPerUnit).NotNull().NotEmpty();
        }
    }
}
