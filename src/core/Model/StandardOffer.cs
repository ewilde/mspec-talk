// -----------------------------------------------------------------------
// <copyright file="StandardOffer.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    /// <summary>
    /// Defines a stander offer
    /// </summary>
    public class StandardOffer : IOffer
    {
        /// <inheritdoc />
        public IPerson Lender { get; set; }

        /// <inheritdoc />
        public decimal Rate { get; set; }

        /// <inheritdoc />
        public decimal Amount { get; set; }
    }
}