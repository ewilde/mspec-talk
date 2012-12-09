// -----------------------------------------------------------------------
// <copyright file="RateCalulator.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Model;
using Rule.Financial.Loan.Core.Services;
using Rule.Financial.Loan.Core.ViewModel;

namespace Rule.Financial.Loan.Console
{
    using System;

    using Financial.Loan.Core.Data;
    using Financial.Loan.Core.Model;
    using Financial.Loan.Core.Services;
    using Financial.Loan.Core.ViewModel;

    /// <summary>
    /// Calculates the best available quote.
    /// </summary>
    public class RateCalulator : IRateCalulator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RateCalulator"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="consoleWriter">The console writer.</param>
        /// <param name="viewModel">The view model.</param>
        public RateCalulator(ILoanQuoteController controller, IConsoleWriter consoleWriter, ILoanQuoteViewModel viewModel)
        {
            this.Controller = controller;
            this.ConsoleWriter = consoleWriter;
            this.ViewModel = viewModel;
        }

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        public ILoanQuoteController Controller { get; set; }

        /// <summary>
        /// Gets or sets the console writer.
        /// </summary>
        /// <value>
        /// The console writer.
        /// </value>
        public IConsoleWriter ConsoleWriter { get; set; }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public ILoanQuoteViewModel ViewModel { get; set; }

        /// <inheritdoc />
        public bool Calculate(decimal amount)
        {
            bool success = true;
            
            try
            {
                this.ViewModel.Quote = this.Controller.Prepare(amount);

                this.ConsoleWriter.WriteInformation(string.Format("Requested amount: {0}", this.ViewModel.RequestedAmount));
                this.ConsoleWriter.WriteInformation(string.Format("Rate: {0}", this.ViewModel.Rate));
                this.ConsoleWriter.WriteInformation(string.Format("Monthly repayment: {0}", this.ViewModel.MonthlyRepayment));
                this.ConsoleWriter.WriteInformation(string.Format("Total repayment: {0}", this.ViewModel.TotalRepayment));
            }
            catch (InsuffficientOffersException insuffficientOffersException)
            {
                this.ConsoleWriter.WriteError(insuffficientOffersException.Message);
                success = false;
            }
            catch (InvalidAmountRequestedException amountRequestedException)
            {
                this.ConsoleWriter.WriteError(amountRequestedException.Message);
                success = false;
            }
            catch (Exception exception)
            {
                this.ConsoleWriter.WriteError(exception.ToString());
                success = false;
            }

            return success;
        }
    }
}