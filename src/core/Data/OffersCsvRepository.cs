// -----------------------------------------------------------------------
// <copyright file="OffersCsvRepository.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Model;
using Rule.Financial.Loan.Core.Services;

namespace Rule.Financial.Loan.Core.Data
{
    using System;

    using Financial.Loan.Core.Model;
    using Financial.Loan.Core.Services;

    /// <summary>
    /// A repository for reading offers from a file stored in csv format
    /// </summary>
    public class OffersCsvRepository : FileRepository<IOffer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffersCsvRepository"/> class.
        /// </summary>
        /// <param name="fileService">The file service.</param>
        /// <param name="repositorySettings">The repository settings.</param>
        /// <param name="configurationService">The configuration service.</param>
        public OffersCsvRepository(IFileService fileService, IRepositorySettings repositorySettings, IConfigurationService configurationService) : base(fileService, repositorySettings, configurationService)
        {
            this.MappingFunction = CreateOffer;
        }

        /// <summary>
        /// Creates an <see cref="IOffer"/> given a specific <paramref name="line"/> in csv format.
        /// </summary>
        /// <param name="line">The line in csv format.</param>
        /// <returns>A new <see cref="IOffer"/> based on the given <paramref name="line"/>.</returns>
        public static IOffer CreateOffer(string line)
        {
            string[] items = line.Split(new[] { ',' });
            return new StandardOffer
            {
                Lender = new Person { Name = items[0] },
                Amount = Convert.ToDecimal(items[2]),
                Rate = Convert.ToDecimal(items[1])
            };
        }
    }
}