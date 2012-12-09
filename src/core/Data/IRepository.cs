// -----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Rule.Financial.Loan.Core.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the behavior off a repository for a given <typeparam name="TModel">mode</typeparam>.
    /// </summary>
    /// <typeparam name="TModel">The type of model</typeparam>
    public interface IRepository<TModel>
    {
        /// <summary>
        /// Gets or sets the repository settings.
        /// </summary>
        /// <value>
        /// The repository settings.
        /// </value>
        IRepositorySettings RepositorySettings { get; set; }

        /// <summary>
        /// Gets all the instances for this repository.
        /// </summary>
        /// <returns>All the instances for this repository</returns>
        IEnumerable<TModel> Get();

        /// <summary>
        /// Creates the specified model in the repository.
        /// </summary>
        /// <param name="model">The model to create.</param>
        void Create(TModel model);
    }
}