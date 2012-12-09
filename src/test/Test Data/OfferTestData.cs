// -----------------------------------------------------------------------
// <copyright file="OfferTestData.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Data;
using Rule.Financial.Loan.Core.Model;
using Rule.Financial.Loan.Core.Services;

namespace Rule.Financial.Loan.Test
{
    using System.Collections.Generic;

    using Machine.Fakes;
    using Machine.Fakes.Adapters.Moq;
    using Machine.Fakes.Sdk;

    using Moq;

    using Financial.Loan.Core.Data;
    using Financial.Loan.Core.Model;
    using Financial.Loan.Core.Services;

    public class OfferTestData
    {
        /// <summary>
        /// Typical offer record in csv format.
        /// </summary>
        public const string HeaderCsvTestData = "Lender,Rate,Available";

        /// <summary>
        /// Typical offer record in csv format.
        /// </summary>
        public const string BobsCsvTestData = "Bob,0.075,640";

        /// <summary>
        /// Typical offer record in csv format.
        /// </summary>
        public const string JohnsCsvTestData = "John,0.081,360";

        /// <summary>
        /// Typical offer record in csv format.
        /// </summary>
        public const string BetterOfferThanJohnsCsvTestData = "John,0.051,360";

        /// <summary>
        /// Type offer record
        /// </summary>
        public static IOffer BobsOffer = OffersCsvRepository.CreateOffer(BobsCsvTestData);

        /// <summary>
        /// Type offer record
        /// </summary>
        public static IOffer JohnsOffer = OffersCsvRepository.CreateOffer(JohnsCsvTestData);

        /// <summary>
        /// Type offer record
        /// </summary>
        public static IOffer BetterOfferThanJohn = OffersCsvRepository.CreateOffer(BetterOfferThanJohnsCsvTestData);
    }

    public class OffersInFile
    {
        private static string[] Offers;
        public OffersInFile(string[] offers)
        {
            Offers = offers;
        }

        OnEstablish context = fakeAccessor =>
        {

            SpecificationController<IRepository<IOffer>, MoqFakeEngine> controller = (SpecificationController<IRepository<IOffer>, MoqFakeEngine>)fakeAccessor;
            ((FileRepository<IOffer>)controller.Subject).MappingFunction = OffersCsvRepository.CreateOffer;

            fakeAccessor
                .The<IFileService>()
                .WhenToldTo(x => x.ReadAllLines(Moq.It.IsAny<string>()))
                .Return(Offers);
        };
    }

    public class OffersRepository
    {
        private static IEnumerable<IOffer> Offers;
        public OffersRepository(IEnumerable<IOffer> offers)
        {
            Offers = offers;
        }

        OnEstablish context = fakeAccessor =>
        {

            fakeAccessor
                .The<IRepository<IOffer>>()
                .WhenToldTo(x => x.Get())
                .Return(Offers);
        };
    }

    public class StandardFakeLoanController
    {
        private static bool ThrowExceptionOnPrepare;
        private static decimal RequestedAmount;
        private static decimal Rate;
        private static decimal MonthlyRepayment;
        private static decimal TotalRepayment;

        public StandardFakeLoanController(decimal requestedAmount, decimal rate, decimal monthlyRepayment, decimal totalRepayment, bool throwExceptionOnPrepare = false)
        {
            ThrowExceptionOnPrepare = throwExceptionOnPrepare;
            RequestedAmount = requestedAmount;
            Rate = rate;
            MonthlyRepayment = monthlyRepayment;
            TotalRepayment = totalRepayment;
        }

        OnEstablish context = fakeAccessor =>
            {
                if (!ThrowExceptionOnPrepare)
                {
                    fakeAccessor.The<ILoanQuoteController>().WhenToldTo(x => x.Prepare(RequestedAmount)).Return(
                        new StandardLoanQuote
                            {
                                RequestedAmount = RequestedAmount,
                                Rate = Rate,
                                MonthlyRepayment = MonthlyRepayment,
                                TotalRepayment = TotalRepayment
                            });
                }
                else
                {
                    fakeAccessor.The<ILoanQuoteController>().WhenToldTo(x => x.Prepare(RequestedAmount)).Throw(new InsuffficientOffersException());
                }
            };
    }

    public class StandardLoan
    {
        public StandardLoan(IEnumerable<IOffer> offers, decimal amount)
        {
            this.Quote = new StandardLoanQuote();
            var repo = new Moq.Mock<IRepository<IOffer>>();
            repo.Setup(call => call.Get()).Returns(offers);
            var controller = new LoanQuoteController(repo.Object, this.Quote);
            Quote = controller.Prepare(amount);
        }

        public ILoanQuote Quote { get; set; }
    }
}