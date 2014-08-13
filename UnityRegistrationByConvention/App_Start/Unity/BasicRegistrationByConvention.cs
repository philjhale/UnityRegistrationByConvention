using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace UnityRegistrationByConvention.Unity
{
	public class BasicRegistrationByConvention : RegistrationConvention
	{
		public override IEnumerable<Type> GetTypes()
		{
			return AllClasses.FromLoadedAssemblies();
		}

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