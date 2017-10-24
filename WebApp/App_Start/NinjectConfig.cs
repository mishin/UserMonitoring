using System;
using System.Reflection;
using Apache.Ignite.Core;
using Ninject;
using WebApp.Repos;
using WebApp.Services;

namespace WebApp
{
    public class NinjectConfig
    {
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });

        private static void RegisterServices(KernelBase kernel)
        {
            kernel.Bind<IUsersService>()
                .To<UsersService>()
                .InSingletonScope();

            var ignite = Ignition.Start();
            kernel.Bind<IRepository>()
                .To<IgniteRepository>()
                .InSingletonScope()
                .WithConstructorArgument(nameof(ignite), ignite);

            kernel.Bind<UpdatesHub>()
                .ToSelf()
                .InSingletonScope();
        }
    }
}