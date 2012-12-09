// -----------------------------------------------------------------------
// <copyright file="IPerson.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    /// <summary>
    /// Defines behaviour and attributes common to all people
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        /// <value>
        /// The name of the person.
        /// </value>
        string Name { get; set; }
    }
}