// -----------------------------------------------------------------------
// <copyright file="AssignedOffer.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    /// <summary>
    /// Represents an <see cref="IOffer"/> that has been assigned to a <see cref="ILoanQuote"/>.
    /// </summary>
    public class AssignedOffer : IAssignedOffer
    {
        /// <inheritdoc />
        public decimal AmountAssigned { get; set; }

        /// <inheritdoc />
        public IOffer Offer { get; set; }

        /// <inheritdoc />
        public ILoanQuote Quote { get; set; }
    }
}