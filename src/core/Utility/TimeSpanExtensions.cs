// -----------------------------------------------------------------------
// <copyright file="TimeSpanExtensions.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Utility
{
    using System;

    /// <summary>
    /// Adds handy method to <see cref="TimeSpan"/>.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Roughly calculates the number of years.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <returns>The number of years</returns>
        public static int Years(this TimeSpan timespan)
        {
            return (int)((double)timespan.Days / 365.2425);
        }

        /// <summary>
        /// Roughly calculates the number of months.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <returns>The number of months</returns>
        public static int Months(this TimeSpan timespan)
        {
            return (int)((double)timespan.Days / 30.436875);
        }
    }
}