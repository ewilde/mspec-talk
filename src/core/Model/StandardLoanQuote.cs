// -----------------------------------------------------------------------
// <copyright file="StandardLoanQuote.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Implements the behaviour of a standard <see cref="ILoanQuote"/>.
    /// </summary>
    public class StandardLoanQuote : ILoanQuote
    {
        /// <summary>
        /// The requested amount for the loan.
        /// </summary>
        private decimal requestedAmount;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardLoanQuote"/> class.
        /// </summary>
        public StandardLoanQuote()
        {
            this.RepaymentTermInMonths = 36;
            this.Currency = new CultureInfo("en-gb").NumberFormat;
            this.AllowedIncrement = 100;
            this.MinimumLoanRequest = 1000;
            this.MaximumLoanRequest = 15000;
            this.Lenders = new List<IAssignedOffer>();
        }

        /// <inheritdoc />
        public decimal RequestedAmount
        {
            get
            {
                return this.requestedAmount;
            }

            set
            {
                if (value > this.MaximumLoanRequest)
                {
                    throw new InvalidAmountRequestedException(
                        string.Format(
                                "I'm sorry {0} is more than the maximum allowed. Please specify an amount no more than {1}.",
                                value.ToString("c", this.Currency),
                                this.MaximumLoanRequest.ToString("c", this.Currency)));
                }

                if (value < this.MinimumLoanRequest)
                {
                    throw new InvalidAmountRequestedException(
                        string.Format(
                                "I'm sorry {0} is less than the maximum allowed. Please specify an amount no less than {1}.",
                                value.ToString("c", this.Currency),
                                this.MinimumLoanRequest.ToString("c")));
                }

                if (value % this.AllowedIncrement > 0)
                {
                    throw new InvalidAmountRequestedException(
                        string.Format(
                                "I'm sorry {0} is not an increment of {1}. Please specify an amount of any {1} increment between {2} and {3} inclusive.",
                                value.ToString("c", this.Currency),
                                this.AllowedIncrement.ToString("c", this.Currency),
                                this.MinimumLoanRequest.ToString("c", this.Currency),
                                this.MaximumLoanRequest.ToString("c", this.Currency)));
                }

                this.requestedAmount = value;
            }
        }

        /// <inheritdoc />
        public IPerson Borrower { get; set; }

        /// <inheritdoc />
        public List<IAssignedOffer> Lenders { get; private set; }

        /// <inheritdoc />
        public NumberFormatInfo Currency { get; set; }

        /// <inheritdoc />
        public decimal Rate { get; set; }

        /// <inheritdoc />
        public decimal MonthlyRepayment { get; set; }

        /// <inheritdoc />
        public decimal TotalRepayment { get; set; }

        /// <inheritdoc />
        public int RepaymentTermInMonths { get; set; }

        /// <inheritdoc />
        public decimal AllowedIncrement { get; set; }

        /// <inheritdoc />
        public decimal MinimumLoanRequest { get; set; }

        /// <inheritdoc />
        public decimal MaximumLoanRequest { get; set; }

        /// <inheritdoc />
        public void Calculate()
        {
            this.TotalRepayment = this.Lenders.Sum(item => this.CalculateTotalRepaymentAmountPerLender(item));
            this.MonthlyRepayment = this.TotalRepayment / this.RepaymentTermInMonths;
            this.Rate = (decimal)(Math.Pow((double)(this.TotalRepayment / this.RequestedAmount), (1.0 / (this.RepaymentTermInMonths / 12))) - 1);
        }

        /// <summary>
        /// Calculates the total repayment amount per lender.
        /// </summary>
        /// <param name="assignedOffer">The assigned offer.</param>
        /// <returns>The total amount required per lender.</returns>
        private decimal CalculateTotalRepaymentAmountPerLender(IAssignedOffer assignedOffer)
        {
            return assignedOffer.AmountAssigned
                   * (decimal)Math.Pow(
                        (double)(1 + (assignedOffer.Offer.Rate / 12)), 
                        this.RepaymentTermInMonths);
        }
    }
}