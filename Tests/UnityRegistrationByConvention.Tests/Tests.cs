using System.Linq;
using NUnit.Framework;

namespace UnityRegistrationByConvention.Tests
{
	[TestFixture]
    public class Tests
    {
		[Test]
		public void Register_core_and_uk_services_registered_correctly()
		{
			var container = Bootstrapper.Initialise();
			var registrations = container.Registrations.ToList();
			
			Assert.True(registrations.Any(x => x.RegisteredType.Name == "ICoreUserService" && x.MappedToType.Name == "CoreUserService"));
			Assert.True(registrations.Any(x => x.RegisteredType.Name == "ICoreLoginService" && x.MappedToType.Name == "UkLoginService"));
		}
    }
}
