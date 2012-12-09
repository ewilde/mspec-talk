// -----------------------------------------------------------------------
// <copyright file="IRateCalulator.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Console
{
    /// <summary>
    /// Defines the behaviour of the rate calculator
    /// </summary>
    public interface IRateCalulator
    {
        /// <summary>
        /// Calculates the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns><c>true</c> if calculation succeeded; otherwise <c>false</c>.</returns>
        bool Calculate(decimal amount);
    }
}