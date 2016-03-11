using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using JobLineBUS;

namespace JobLineAPI.App_Start
{
    public static class AutofacInitialize
    {
        public static void InitializeIoc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof (WebApiApplication).Assembly);

            var connectString = WebConfigurationManager.ConnectionStrings["JobLineDb"].ConnectionString;
            builder.RegisterModule(new BusModule(connectString));

            var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver((IContainer) container);
        }
    }
}