// -----------------------------------------------------------------------
// <copyright file="ILoanQuoteController.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace Rule.Financial.Loan.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the behaviour required to collect <see cref="IOffer"/>s and prepare a <see cref="ILoanQuote"/>.
    /// </summary>
    public interface ILoanQuoteController
    {
        /// <summary>
        /// Prepares a <see cref="ILoanQuote"/> based on the currently available offers and the <paramref name="amount"/> requested.
        /// </summary>
        /// <param name="amount">The amount of money being requested.</param>
        /// <returns>A <see cref="ILoanQuote"/> using the best possible rate.</returns>
        /// <exception cref="InsuffficientOffersException">Thrown if there are not enough offers available fulfil the amount of loan being quoted for.</exception>
        ILoanQuote Prepare(decimal amount);
    }
}
