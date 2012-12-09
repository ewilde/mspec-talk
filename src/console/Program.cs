using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rule.Financial.Loan.Console.Configuration;
using Rule.Financial.Loan.Core.Configuration;
using Rule.Financial.Loan.Core.Data;

namespace Rule.Financial.Loan.Console
{
    using System.Reflection;

    using Autofac;

    using Financial.Loan.Console.Configuration;
    using Financial.Loan.Core.Configuration;
    using Financial.Loan.Core.Data;

    /// <summary>
    /// Entry point for the console application, responsible for bootstraping, parsing commandline arguments and
    /// kicking off the rate calculation.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        /// <param name="rateCalulator">The rate calulator.</param>
        /// <param name="repositorySettings">The repository settings.</param>
        /// <param name="repositoryLocation">The repository location.</param>
        /// <param name="amountRequested">The amount requested.</param>
        public Program(IRateCalulator rateCalulator, IRepositorySettings repositorySettings, string repositoryLocation, decimal amountRequested)
        {
            this.RateCalulator = rateCalulator;
            this.RepositorySettings = repositorySettings;
            this.RepositorySettings.ConnectionString = repositoryLocation;
            this.RepositoryLocation = repositoryLocation;
            this.AmountRequested = amountRequested;
        }

        /// <summary>
        /// Gets or sets the rate calulator.
        /// </summary>
        /// <value>
        /// The rate calulator.
        /// </value>
        public IRateCalulator RateCalulator { get; set; }

        /// <summary>
        /// Gets or sets the repository settings.
        /// </summary>
        /// <value>
        /// The repository settings.
        /// </value>
        public IRepositorySettings RepositorySettings { get; set; }

        /// <summary>
        /// Gets or sets the repository location.
        /// </summary>
        /// <value>
        /// The repository location.
        /// </value>
        public string RepositoryLocation { get; set; }

        /// <summary>
        /// Gets or sets the amount requested.
        /// </summary>
        /// <value>
        /// The amount requested.
        /// </value>
        public decimal AmountRequested { get; set; }

        /// <summary>
        /// Main entry point for the console application, currently two command line
        /// arguments are supported
        /// </summary>
        /// <param name="args">The command line arguments, the first is the location to the csv formatted offers file and
        /// the second is the amount requested for the loan quote.</param>
        /// <returns>Returns 0 if the execution path happened as expected; otherwise returns -1.</returns>
        public static int Main(string[] args)
        {
            using (var container = Bootstrap())
            {
                string repositoryLocation = args[0];
                decimal amount = Convert.ToDecimal(args[1]);

                if (container.Resolve<Program>(Autofac.TypedParameter.From(repositoryLocation), TypedParameter.From(amount)).Run())
                {
                    return 0;
                }

                return -1;
            }
        }

        /// <summary>
        /// Runs the rate calculator.
        /// </summary>
        /// <returns><c>true</c> if calculation succeeded; otherwise <c>false</c>.</returns>
        public bool Run()
        {
            return this.RateCalulator.Calculate(this.AmountRequested);
        }

        /// <summary>
        /// Bootstraps this instance configures autofac.
        /// </summary>
        /// <returns>The configured autofac container.</returns>
        private static IContainer Bootstrap()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DataModule>();
            containerBuilder.RegisterModule<ModelModule>();
            containerBuilder.RegisterModule<ServicesModule>();
            containerBuilder.RegisterModule<ViewModelModule>();
            containerBuilder.RegisterModule<ConsoleModule>();
            
            return containerBuilder.Build();
        }
    }
}
