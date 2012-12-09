// -----------------------------------------------------------------------
// <copyright file="CsvFileRepositoryTests.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Data;
using Rule.Financial.Loan.Core.Machine.Fakes;
using Rule.Financial.Loan.Core.Model;
using Rule.Financial.Loan.Core.Services;
using Rule.Financial.Loan.Test;

namespace Rule.Financial.Loan.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Machine.Fakes;
    using Machine.Fakes.Adapters.Moq;
    using Machine.Fakes.Sdk;
    using Machine.Specifications;

    using Financial.Loan.Core.Machine.Fakes;
    using Financial.Loan.Core.Data;
    using Financial.Loan.Core.Model;
    using Financial.Loan.Core.Services;
    using Financial.Loan.Test;

    [Subject(typeof(FileRepository<IOffer>), "Reading records")]
    public class when_i_get_items_from_the_file_repository : WithConcreteSubject<IRepository<IOffer>, FileRepository<IOffer>>
    {
        Establish context = () => With(new OffersInFile(new[] { OfferTestData.HeaderCsvTestData, OfferTestData.BobsCsvTestData, OfferTestData.JohnsCsvTestData }));    

        Because of = () => result = Subject.Get();

        It should_read_all_lines_from_the_file = () => The<IFileService>().WasToldTo(call => call.ReadAllLines(null));

        It should_return_the_same_number_of_offers_as_there_are_in_the_file = () => result.Count().ShouldEqual(2);

        static IEnumerable<IOffer> result;                            
    }

   
}