using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training.Bll;

namespace Training.MvcFrontend.App_Start
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<BllAutofactModule>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly); // builder.ResigerType<ProductsController>().AsSelf();
            builder.RegisterType<UserManager<IdentityUser>>().AsSelf()
                                                             .As<UserManager<IdentityUser, string>>();
            builder.RegisterType<UserStore<IdentityUser>>().As<IUserStore<IdentityUser>>();

            builder.RegisterType<SignInManager<IdentityUser, string>>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication)
                                                        .As<IAuthenticationManager>(); //Microsoft.Owin.Host.Systeweb

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); // Autofac MVC összecsatolása, az autofac modszerével fogja feloldani a controllert
        }
    }
}