// -----------------------------------------------------------------------
// <copyright file="ILoanQuoteViewModel.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Model;

namespace Rule.Financial.Loan.Core.ViewModel
{
    using Financial.Loan.Core.Model;

    /// <summary>
    /// Defines the attributes for a typical view model used to display
    /// a <see cref="ILoanQuote"/>s.
    /// </summary>
    public interface ILoanQuoteViewModel
    {
        /// <summary>
        /// Gets the requested amount.
        /// </summary>
        string RequestedAmount { get; }

        /// <summary>
        /// Gets the rate.
        /// </summary>
        string Rate { get; }

        /// <summary>
        /// Gets the monthly repayment.
        /// </summary>
        string MonthlyRepayment { get; }

        /// <summary>
        /// Gets the total repayment.
        /// </summary>
        string TotalRepayment { get; }

        /// <summary>
        /// Gets or sets the quote.
        /// </summary>
        /// <value>
        /// The quote.
        /// </value>
        ILoanQuote Quote { get; set; }
    }
}