// -----------------------------------------------------------------------
// <copyright file="DataModule.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Data;

namespace Rule.Financial.Loan.Core.Configuration
{
    using System.Reflection;

    using Autofac;

    using Financial.Loan.Core.Data;
    using Financial.Loan.Core.Model;

    /// <summary>
    /// Configures the data section of core. 
    /// Registers types in autofac
    /// </summary>
    public class DataModule : Autofac.Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.FullName.StartsWith("Rule.Financial.Loan.Core.Data"))
                .AsImplementedInterfaces()
                .Except<RepositorySettings>();

            builder.RegisterType<RepositorySettings>().AsImplementedInterfaces().SingleInstance();
        }
    }
}