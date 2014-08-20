using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace UnityRegistrationByConvention.Unity
{
	public class BasicRegistrationByConvention : RegistrationConvention
	{
		// Get the classes you want to register
		public override IEnumerable<Type> GetTypes()
		{
			// FromLoadedAssemblies returns assemblies that loaded in the current app domain
			return AllClasses.FromLoadedAssemblies();
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