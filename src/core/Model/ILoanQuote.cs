// -----------------------------------------------------------------------
// <copyright file="ILoanQuote.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Defines behaviour and attributes common to all quote.
    /// </summary>
    public interface ILoanQuote
    {
        /// <summary>
        /// Gets or sets the amount of money being loaned.
        /// </summary>
        /// <value>
        /// The amount of money being loaned.
        /// </value>
        /// <exception cref="InvalidAmountRequestedException">Thrown if the <paramref name="value"/> 
        /// is set below the <see cref="MinimumLoanRequest"/> or above the <see cref="MaximumLoanRequest"/>.</exception>
        decimal RequestedAmount { get; set; }

        /// <summary>
        /// Gets or sets the person who is being quoted for a potential loan.
        /// </summary>
        /// <value>
        /// The person being quoted for a potential loan.
        /// </value>
        IPerson Borrower { get; set; }

        /// <summary>
        /// Gets lenders for the loan.
        /// </summary>
        /// <value>
        /// The lenders for this loan.
        /// </value>
        List<IAssignedOffer> Lenders { get; }

        /// <summary>
        /// Gets or sets the regional information used to determine currency, for <see cref="MonthlyRepayment"/>, <see cref="TotalRepayment"/>,
        /// <see cref="MinimumLoanRequest"/> and <see cref="MaximumLoanRequest"/>.
        /// </summary>
        /// <value>
        /// The the regional information used to determine currency.
        /// </value>
        NumberFormatInfo Currency { get; set; }

        /// <summary>
        /// Gets or sets the rate for the loan quote.
        /// </summary>
        /// <value>
        /// The rate for the loan quote.
        /// </value>
        decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets the monthly repayment amount.
        /// </summary>
        /// <value>
        /// The monthly repayment amount.
        /// </value>
        decimal MonthlyRepayment { get; set; }

        /// <summary>
        /// Gets or sets the total repayment amount.
        /// </summary>
        /// <value>
        /// The total repayment amount.
        /// </value>
        decimal TotalRepayment { get; set; }

        /// <summary>
        /// Gets or sets the length of the repayment term in months.
        /// </summary>
        /// <value>
        /// The length of the repayment term in months.
        /// </value>
        int RepaymentTermInMonths { get; set; }

        /// <summary>
        /// Gets or sets the allowed increment value when changing the <see cref="RequestedAmount"/>.
        /// </summary>
        /// <value>
        /// The allowed increment.
        /// </value>
        decimal AllowedIncrement { get; set; }

        /// <summary>
        /// Gets or sets the minimum loan request.
        /// </summary>
        /// <value>
        /// The minimum loan request.
        /// </value>
        decimal MinimumLoanRequest { get; set; }

        /// <summary>
        /// Gets or sets the maximum loan request.
        /// </summary>
        /// <value>
        /// The maximum loan request.
        /// </value>
        decimal MaximumLoanRequest { get; set; }

        /// <summary>
        /// Based on the supplied values of <see cref="Rate"/>, <see cref="RequestedAmount"/> and the list of <see cref="Lenders"/>, 
        /// calculates and assigns the values for <see cref="TotalRepayment"/> and <see cref="MonthlyRepayment"/>.
        /// </summary>
        void Calculate();
    }
}