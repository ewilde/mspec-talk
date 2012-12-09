// -----------------------------------------------------------------------
// <copyright file="ModelModule.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Configuration
{
    using System.Reflection;

    using Autofac;

    using Module = Autofac.Module;

    /// <summary>
    /// Responsible for registering all model types
    /// </summary>
    public class ModelModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.FullName.StartsWith("Rule.Financial.Loan.Core.Model"))
                .AsImplementedInterfaces();
        }
    }
}