using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FrameworkExample.Core.DataAccess.NHibernate;
using System.Reflection;

namespace FrameworkExample.Northwind.DataAccess.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper : NHibernateHelper
    {
        protected override global::NHibernate.ISessionFactory InitializeFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(x => x.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
            ;
        }
    }
}
