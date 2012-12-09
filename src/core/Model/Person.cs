// -----------------------------------------------------------------------
// <copyright file="Person.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Model
{
    /// <summary>
    /// Defines the behaviour for a normal perons
    /// </summary>
    public class Person : IPerson
    {
        /// <inheritdoc />
        public string Name { get; set; }
    }
}