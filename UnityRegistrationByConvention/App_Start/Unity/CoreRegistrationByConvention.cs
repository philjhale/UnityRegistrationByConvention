using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace UnityRegistrationByConvention.Unity
{
	public class CoreRegistrationByConvention : RegistrationConvention
	{
		// Get the classes you want to register
		public override IEnumerable<Type> GetTypes()
		{
			// AllClasses.FromLoadedAssemblies() loads assemblies in the current app domain and is required for MVC project.
			// AllClasses.FromAssembliesInBasePath() loads assemblies from the bin directory and required so unit tests work. 
			// AllClasses.FromAssembliesInBasePath() alone doesn't work for the MVC project because the base path of an MVC project isn't the bin directory
			return AllClasses.FromLoadedAssemblies().Concat(AllClasses.FromAssembliesInBasePath())
				.Where(x => x.Assembly.FullName.Contains("UnityRegistrationByConvention.Services")
					&& x.Name.Contains("Core"));
		}

		// Get the interfaces you want to map against the concrete class. E.g. Return ITenant for Tenant concrete class
		public override Func<Type, IEnumerable<Type>> GetFromTypes()
		{
			return WithMappings.FromMatchingInterface;
		}

		public override Func<Type, string> GetName()
		{
			return WithName.Default;
		}

		public override Func<Type, LifetimeManager> GetLifetimeManager()
		{
			return WithLifetime.ContainerControlled;
		}

		public override Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers()
		{
			return null;
		}
	}
}