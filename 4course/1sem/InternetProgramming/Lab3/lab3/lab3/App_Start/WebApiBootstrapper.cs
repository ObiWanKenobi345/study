using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Contracts.Core;
using Contracts.Mapper;
using Contracts.Services;
using Contracts.UnitOfWork;
using lab3.Context;
using lab3.Core;
using lab3.Mapper;
using lab3.Services;

namespace lab3.App_Start
{
    public static class WebApiBootstrapper
    {
        public static IContainer Container;

        public static void Register(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        { 
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<StudentContext>()
                .As<DbContext>()
                .InstancePerRequest();

            builder.RegisterType<UnitOfWork.UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            builder.RegisterType<StudentDb>()
                .As<IStudentDb>()
                .InstancePerRequest();

            builder.RegisterType<StudentMapperConfig>()
                .As<IStudentMapperConfig>()
                .InstancePerRequest();

            builder.RegisterType<StudentService>()
                .As<IStudentService>()
                .InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}