using System;

using Machine.Specifications;
using Rule.Financial.Loan.Core.Configuration;
using Rule.Financial.Loan.Core.Data;
using Rule.Financial.Loan.Core.Model;

namespace Rule.Financial.Loan.Tests.UnitTests
{
    using System.Linq;

    using Autofac;
    using Autofac.Core;

    using Machine.Fakes;

    using Financial.Loan.Core.Data;
    using Financial.Loan.Core.Model;

    [Subject(typeof(DataModule), "registering types")]
    public class when_adding_a_data_module_to_the_autofac_container : WithSubject<ContainerBuilder>
    {
        Because of = () =>
            {
                Subject.RegisterModule<DataModule>();
                Container = Subject.Build();
            };

        It should_register_repository_types = () => { Container.IsRegistered<IRepository<IOffer>>().ShouldBeTrue(); };

        It should_register_repository_settings_as_a_singleton = () =>
            (Container.Resolve<IRepositorySettings>() == Container.Resolve<IRepositorySettings>()).ShouldBeTrue();

        static IContainer Container;
    }
}