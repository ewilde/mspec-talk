// -----------------------------------------------------------------------
// <copyright file="ViewModelModule.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Configuration
{
    using System.Reflection;

    using Autofac;

    using Module = Autofac.Module;

    /// <summary>
    /// Registers the types from the view model namespace
    /// </summary>
    public class ViewModelModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.FullName.StartsWith("Rule.Financial.Loan.Core.ViewModel"))
                .AsImplementedInterfaces();
        }
    }
}