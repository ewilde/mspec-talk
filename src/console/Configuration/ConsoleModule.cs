// -----------------------------------------------------------------------
// <copyright file="ConsoleModule.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Console.Configuration
{
    using System.Reflection;

    using Autofac;

    using Module = Autofac.Module;

    /// <summary>
    /// Responsible for registering all types in the console library.
    /// </summary>
    public class ConsoleModule : Module
    {
        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();
            builder.RegisterType<Program>();
        }
    }
}