using System;

using Machine.Specifications;
using Rule.Financial.Loan.Core.Configuration;
using Rule.Financial.Loan.Core.Model;

namespace Rule.Financial.Loan.Tests.UnitTests
{
    using Autofac;

    using Machine.Fakes;

    using Financial.Loan.Core.Configuration;
    using Financial.Loan.Core.Data;
    using Financial.Loan.Core.Model;

    [Subject(typeof(ModelModule), "registering types")]
    public class when_adding_a_model_module_to_the_autofac_container : WithSubject<ContainerBuilder>
    {
        Because of = () =>
        {
            Subject.RegisterModule<ModelModule>();
            Container = Subject.Build();
        };

        It should_register_types_from_the_model_namespace = () =>
            {
                Container.IsRegistered<IOffer>().ShouldBeTrue();
                Container.Resolve<IOffer>().ShouldBeOfType<StandardOffer>();
            };

        static IContainer Container;
    }
}