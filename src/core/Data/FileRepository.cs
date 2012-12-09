// -----------------------------------------------------------------------
// <copyright file="FileRepository.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Services;

namespace Rule.Financial.Loan.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Financial.Loan.Core.Services;

    /// <summary>
    /// Defines the behaviour of a simple file based csv forat repository.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class FileRepository<TModel> : IRepository<TModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileRepository{TModel}"/> class.
        /// </summary>
        /// <param name="fileService">The file service.</param>
        /// <param name="repositorySettings">The repository settings.</param>
        /// <param name="configurationService">The configuration service.</param>
        public FileRepository(IFileService fileService, IRepositorySettings repositorySettings, IConfigurationService configurationService)
        {
            this.FileService = fileService;
            this.RepositorySettings = repositorySettings;
            this.ConfigurationService = configurationService;
        }

        /// <summary>
        /// Gets or sets the file service.
        /// </summary>
        /// <value>
        /// The file service.
        /// </value>
        public IFileService FileService { get; set; }

        /// <summary>
        /// Gets or sets the repository settings.
        /// </summary>
        /// <value>
        /// The repository settings.
        /// </value>
        public IRepositorySettings RepositorySettings { get; set; }

        /// <summary>
        /// Gets or sets the mapping function that takes in a line from the CSV file and returns the model for said line.
        /// </summary>
        /// <value>
        /// The mapping function.
        /// </value>
        public Func<string, TModel> MappingFunction { get; set; }

        /// <summary>
        /// Gets or sets the configuration service.
        /// </summary>
        /// <value>
        /// The configuration service.
        /// </value>
        public IConfigurationService ConfigurationService { get; set; }
        
        /// <inheritdoc />
        public IEnumerable<TModel> Get()
        {
            return
                new List<TModel>(
                    this.FileService.ReadAllLines(this.RepositorySettings.ConnectionString).Skip(1).Select(
                        line => this.MappingFunction.Invoke(line)));
        }

        /// <inheritdoc />
        public void Create(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}