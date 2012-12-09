// -----------------------------------------------------------------------
// <copyright file="RepositorySettings.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Data
{
    /// <inheritdoc />
    public class RepositorySettings : IRepositorySettings
    {
        /// <inheritdoc />
        public string ConnectionString { get; set; }
    }
}