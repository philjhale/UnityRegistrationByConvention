using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Services;
using Unity.Mvc4;
using UnityRegistrationByConvention.Unity;

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
  
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
		// Dependencies are injected into HomeController

		// 1. Manual registrations
		//container.RegisterType<ICoreUserService, CoreUserService>(new PerResolveLifetimeManager());
		//container.RegisterType<ICoreLoginService, UkLoginService>(new PerResolveLifetimeManager());
		
		// 2. Very generic registration by convention
		//container.RegisterTypes(
		//	AllClasses.FromLoadedAssemblies(),
		//	WithMappings.FromMatchingInterface,
		//	WithName.Default,
		//	WithLifetime.ContainerControlled);

		// 3. Simplest possible extension of RegistrationConvention. It does exactly the same as the statement above
		//container.RegisterTypes(new BasicRegistrationByConvention());

		// 4. More complex example of RegistrationConvention extension. 
		// The use case is a problem I face at work.
		// Core services are created and in some cases they are overridden by country services. E.g. CoreLoginService, UkLoginService.
		// Where country overrides exists in must be injected instead of the core service
		container.RegisterTypes(new CoreRegistrationByConvention());
		container.RegisterTypes(new UkRegistrationByConvention(), overwriteExistingMappings: true);
    }
  }
}