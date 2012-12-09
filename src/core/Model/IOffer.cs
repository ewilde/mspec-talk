// -----------------------------------------------------------------------
// <copyright file="IOffer.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    /// <summary>
    /// Defines behaviour and attibutes common to all offers.
    /// </summary>
    public interface IOffer
    {
        /// <summary>
        /// Gets or sets the lender.
        /// </summary>
        /// <value>
        /// The lender.
        /// </value>
        IPerson Lender { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets the available amount on offer.
        /// </summary>
        /// <value>
        /// The available amount of money on offer.
        /// </value>
        decimal Amount { get; set; }
    }
}