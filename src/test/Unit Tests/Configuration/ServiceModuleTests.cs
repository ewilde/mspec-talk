using System;

using Machine.Specifications;
using Rule.Financial.Loan.Core.Configuration;
using Rule.Financial.Loan.Core.Services;

namespace Rule.Financial.Loan.Tests.UnitTests
{
    using System.Linq;

    using Autofac;
    using Autofac.Core;

    using Machine.Fakes;

    using Financial.Loan.Core.Data;
    using Financial.Loan.Core.Model;
    using Financial.Loan.Core.Services;

    [Subject(typeof(ServicesModule), "registering types")]
    public class when_adding_a_services_module_to_the_autofac_container : WithSubject<ContainerBuilder>
    {
        Because of = () =>
            {
                Subject.RegisterModule<ServicesModule>();
                Container = Subject.Build();
            };

        It should_register_repository_types = () => { Container.IsRegistered<IConfigurationService>().ShouldBeTrue(); };

        It should_register_types_as_singletons =
            () => Container.ComponentRegistry.Registrations.All(item => item.Sharing.Equals(InstanceSharing.Shared));
        
        static IContainer Container;
    }
}