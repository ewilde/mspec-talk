using System;

using Machine.Specifications;
using Rule.Financial.Loan.Core.Configuration;
using Rule.Financial.Loan.Core.ViewModel;

namespace Rule.Financial.Loan.Tests.UnitTests
{
    using Autofac;

    using Machine.Fakes;

    using Financial.Loan.Core.Configuration;
    using Financial.Loan.Core.ViewModel;

    [Subject(typeof(ViewModelModule), "registering types")]
    public class when_adding_a_view_model_module_to_the_autofac_container : WithSubject<ContainerBuilder>
    {
        Because of = () =>
        {
            Subject.RegisterModule<ViewModelModule>();
            Subject.RegisterModule<ModelModule>(); // Dependant module
            Container = Subject.Build();
        };

        It should_register_types_from_the_model_namespace = () =>
            {
                Container.IsRegistered<ILoanQuoteViewModel>().ShouldBeTrue();
                Container.Resolve<ILoanQuoteViewModel>().ShouldBeOfType<StandardLoanQuoteViewModel>();
            };

        static IContainer Container;
    }
}