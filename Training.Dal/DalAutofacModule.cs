using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Training.Dal.Repositories;

namespace Training.Dal
{
    public class DalAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<EntityFrameworkUnitOfWork>().As<IUnitOfWork>(); //itt történik meg az interface és az implementációjának összecsatolása, összerendelése
            builder.RegisterType<EntityFrameworkCategorytRepository>().As<ICategoryRepository>();
            builder.RegisterType<EntityFrameworkProductRepository>().As<IProductRepository>();
            builder.RegisterType<TrainingModel>().As<DbContext>().AsSelf().InstancePerLifetimeScope(); // nincs függősége, interface-e önmagéval rendelem össze
            /* IntasncePerLifetimeScope biztosítja azt, hogy a TrainingModel csak egyszer példányosodjon ugyanazon scopen belül*/
        }
    }
}
