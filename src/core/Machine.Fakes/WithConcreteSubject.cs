// -----------------------------------------------------------------------
// <copyright file="WithConcreteSubject.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace Rule.Financial.Loan.Core.Machine.Fakes
{
    using System.Diagnostics.CodeAnalysis;

    using global::Machine.Fakes;
    using global::Machine.Specifications;

    /// <summary>
    /// Creates a subject based on the supplied <typeparamref name="TInterface"/> but 
    /// created using a concrete type instead of a mock.
    /// </summary>
    /// <typeparam name="TInterface">The type of the interface.</typeparam>
    /// <typeparam name="TConcreteType">The type of the concrete type.</typeparam>
    public class WithConcreteSubject<TInterface, TConcreteType> : WithSubject<TInterface>
        where TInterface : class where TConcreteType : TInterface
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
            Justification = "Reviewed. Suppression is OK here.")]
        private Establish context = () => Configure(x => x.For<TInterface>().Use<TConcreteType>());
    }
}