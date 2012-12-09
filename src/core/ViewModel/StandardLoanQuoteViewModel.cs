// -----------------------------------------------------------------------
// <copyright file="StandardLoanQuoteViewModel.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Model;

namespace Rule.Financial.Loan.Core.ViewModel
{
    using Financial.Loan.Core.Model;

    /// <summary>
    /// A standard way to represent a <see cref="Quote"/> to a given view.
    /// Mainly this determines display formatting of decimal places, currency and 
    /// interest rates.
    /// </summary>
    public class StandardLoanQuoteViewModel : ILoanQuoteViewModel
    {
        /// <summary>
        /// Gets or sets the quote.
        /// </summary>
        /// <value>
        /// The quote.
        /// </value>
        public ILoanQuote Quote { get; set; }

        /// <summary>
        /// Gets the requested amount with 0 decimal places. Display formated as £XXXX.
        /// </summary>
        public string RequestedAmount
        {
            get
            {
                return this.Quote.RequestedAmount.ToString("c", this.Quote.Currency).Replace(".00", string.Empty);
            }
        }

        /// <summary>
        /// Gets the rate to one decimal place. Display formated as X.X%.
        /// </summary>
        public string Rate
        {
            get
            {
                return (this.Quote.Rate * 100).ToString("F1", this.Quote.Currency) + "%";
            }
        }

        /// <summary>
        /// Gets the monthly repayment with 2 decimal places. Display formated as £XXXX.XX.
        /// </summary>
        public string MonthlyRepayment
        {
            get
            {
                return this.Quote.MonthlyRepayment.ToString("c", this.Quote.Currency);
            }
        }

        /// <summary>
        /// Gets the total repayment with 2 decimal places. Display formated as £XXXX.XX.
        /// </summary>
        public string TotalRepayment
        {
            get
            {
                return this.Quote.TotalRepayment.ToString("c", this.Quote.Currency);
            }
        }
    }
}