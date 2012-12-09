// -----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Market Invoice">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Utility
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Common helper methods for the <see cref="string"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the supplied <paramref name="text"/> to the given <typeparamref name="T"/> using default type convertors.
        /// </summary>
        /// <typeparam name="T">Type to convert to</typeparam>
        /// <param name="text">The text value.</param>
        /// <returns>The instance of <typeparamref name="T"/> with a corresponding value of <paramref name="text"/></returns>
        public static T To<T>(this string text)
        {
            return (T)Convert.ChangeType(text, typeof(T), CultureInfo.CurrentCulture);
        }     
    }
}