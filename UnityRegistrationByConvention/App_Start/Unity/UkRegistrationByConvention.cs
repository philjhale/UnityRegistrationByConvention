﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace UnityRegistrationByConvention.Unity
{
	public class UkRegistrationByConvention : RegistrationConvention
	{
		private static readonly Type[] emptyTypes = new Type[0];

		public override IEnumerable<Type> GetTypes()
		{
			return AllClasses.FromLoadedAssemblies().Where(x => x.Assembly.FullName.Contains("UnityRegistrationByConvention.Services"));
		}

		public override Func<Type, IEnumerable<Type>> GetFromTypes()
		{
			return GetInterfaces;
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

		// This is based on Unity method WithMappings.FromMatchingInterface
		private IEnumerable<Type> GetInterfaces(Type implementationType)
		{
			var matchingCountryInterfaceName = "I" + implementationType.Name;
			var matchingCoreInterfaceName = "I" + implementationType.Name.Replace("Uk", "Core");

			var countryInterface = GetImplementedInterfacesToMap(implementationType).FirstOrDefault(i => string.Equals(i.Name, matchingCountryInterfaceName, StringComparison.Ordinal));
			var coreInterface = GetImplementedInterfacesToMap(implementationType).FirstOrDefault(i => string.Equals(i.Name, matchingCoreInterfaceName, StringComparison.Ordinal));

			if (countryInterface != null || coreInterface != null)
            {
				var interfaces = new List<Type>();
				if (countryInterface != null) interfaces.Add(countryInterface);
				if (coreInterface != null) interfaces.Add(coreInterface);
                
				return interfaces;
            }
            
            return emptyTypes;
		}

		// Stolen from Unity source code
		private IEnumerable<Type> GetImplementedInterfacesToMap(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            if (!typeInfo.IsGenericType)
            {
                return typeInfo.ImplementedInterfaces;
            }
            else if (!typeInfo.IsGenericTypeDefinition)
            {
                return typeInfo.ImplementedInterfaces;
            }
            else
            {
				// Not needed for the purposes of this project
				throw new NotImplementedException();
                //return FilterMatchingGenericInterfaces(typeInfo);
            }
        }
	}
}