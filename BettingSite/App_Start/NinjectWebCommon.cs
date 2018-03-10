
using BettingSite.App_Start;
using BettingSite.Repositories;
using BettingSite.Services;
using BettingSite.Utility;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.WebApi;
using System;
using System.Web;
using System.Web.Http;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace BettingSite.App_Start
{
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IRepo>().ToMethod(ctx => new Repo("Ninject Rocks!"));

            kernel.Bind<ISportRepository>().To<SportRepository>();
            kernel.Bind<IBonusCalculator>().To<AllSportsBonusCalculator>();
            kernel.Bind<IBonusCalculator>().To<_3PairsSameSportBonusCalculator>();

            kernel.Bind<IBonusCalculatorRunner>().To<BonusCalculatorRunner>();
        }

        public static IKernel CreatePublicKernel()
        {
            if (null == bootstrapper)
                Start();
            else if(null == bootstrapper.Kernel)
            {
                return CreateKernel();
            }

            return bootstrapper.Kernel;
        }
    }
}