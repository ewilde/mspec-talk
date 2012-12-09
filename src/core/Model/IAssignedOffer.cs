// -----------------------------------------------------------------------
// <copyright file="IAssignedOffer.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    /// <summary>
    /// Defines the behaviour when an <see cref="IOffer"/> is assigned to a <see cref="ILoanQuote"/>.
    /// Sometimes not all the amount being offered is required for the <see cref="ILoanQuote"/>
    /// </summary>
    public interface IAssignedOffer
    {
        /// <summary>
        /// Gets or sets the amount being assigned.
        /// </summary>
        /// <value>
        /// The amount of money being assigned.
        /// </value>
        decimal AmountAssigned { get; set; }

        /// <summary>
        /// Gets or sets the offer.
        /// </summary>
        /// <value>
        /// The offer.
        /// </value>
        IOffer Offer { get; set; }

        /// <summary>
        /// Gets or sets the quote.
        /// </summary>
        /// <value>
        /// The quote.
        /// </value>
        ILoanQuote Quote { get; set; }
    }
}