using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace UnityRegistrationByConvention.Unity
{
	public class CoreRegistrationByConvention : RegistrationConvention
	{
		public override IEnumerable<Type> GetTypes()
		{
			// Concat required so registrations work in web project and unit tests. Haven't got my head around why yet
			return AllClasses.FromLoadedAssemblies().Concat(AllClasses.FromAssembliesInBasePath())
				.Where(x => x.Assembly.FullName.Contains("UnityRegistrationByConvention.Services")
					&& x.Name.Contains("Core"));
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