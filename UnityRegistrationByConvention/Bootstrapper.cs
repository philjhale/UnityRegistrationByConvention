using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Services;
using Unity.Mvc4;

namespace UnityRegistrationByConvention
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
		// Manual registrations
		//container.RegisterType<IUserService, UserService>(new PerResolveLifetimeManager());
		//container.RegisterType<ICoreLoginService, UkLoginService>(new PerResolveLifetimeManager());
		
		// Very generic registration by convention
		//container.RegisterTypes(
		//	AllClasses.FromLoadedAssemblies(),
		//	WithMappings.FromMatchingInterface,
		//	WithName.Default,
		//	WithLifetime.ContainerControlled);

		// Simplest possible extension of RegistrationConvention
		//container.RegisterTypes(new BasicRegistrationByConvention());

		// More complex example of RegistrationConvention extension
		container.RegisterTypes(new CoreRegistrationByConvention());
		container.RegisterTypes(new CountryRegistrationByConvention(), overwriteExistingMappings: true);
    }
  }
}