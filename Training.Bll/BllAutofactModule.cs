using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Training.Dal;

namespace Training.Bll
{
    public class BllAutofactModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ProductService>().AsSelf();
            builder.RegisterType<CategoryService>().AsSelf();

            builder.RegisterModule<DalAutofacModule>(); // beregistrálja az összes tipus ami a DalAutofactModuleban van..
        }
    }
}
