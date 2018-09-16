using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;
using System.Web;
using YunMall.Web.BLL.user;
using YunMall.Web.IBLL.user;
using YunMall.Web.IDAL.user;
using YunMall.Web.DAL.user;

namespace YunMall.Web.Core
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            // ���Unity������ 2017��9��19��21:49:39
            container.AddNewExtension<Interception>();

            // �û��߼��Ͳִ��ӿ� 2018��9��15��22:22:54
            container.RegisterType<IUserService, UserServiceImpl>(new ContainerControlledLifetimeManager())
                .Configure<Interception>().SetInterceptorFor<IUserService>(new InterfaceInterceptor());

            container.RegisterType<IUserRepository, UserRepositoryImpl>(new ContainerControlledLifetimeManager())
                .Configure<Interception>().SetInterceptorFor<IUserRepository>(new InterfaceInterceptor());


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

    }
}