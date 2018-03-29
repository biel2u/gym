using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Gym.Domain.Abstract;
using Gym.Domain.Concrete;
using Gym.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Web;
using System.Web.Mvc;
using static Gym.WebUI.ApplicationUserManager;

[assembly: OwinStartupAttribute(typeof(Gym.WebUI.Startup))]
namespace Gym.WebUI
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EFDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

            builder.RegisterType<TrainingRepository>().As<ITrainingRepository>().AsImplementedInterfaces();
            builder.RegisterType<ExerciseRepository>().As<IExerciseRepository>().AsImplementedInterfaces();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            ConfigureAuth(app);
        }
    }
}
