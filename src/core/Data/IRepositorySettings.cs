// -----------------------------------------------------------------------
// <copyright file="IRepositorySettings.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Data
{
    /// <summary>
    /// Defines the settings requirements for repositories.
    /// </summary>
    public interface IRepositorySettings
    {
        /// <summary>
        /// Gets or sets the connection string for this repository.
        /// </summary>
        string ConnectionString { get; set; }     
    }
}