using FluentValidation;
using FrameworkExample.Northwind.Business.ValidationRules.FluentValidation;
using FrameworkExample.Northwind.Entities.Concrete;
using Ninject.Modules;

namespace FrameworkExample.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
