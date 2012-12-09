// -----------------------------------------------------------------------
// <copyright file="LoanQuoteControllerTests.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Machine.Fakes;
using Rule.Financial.Loan.Core.Model;
using Rule.Financial.Loan.Test;

namespace Rule.Financial.Loan.Tests.UnitTests
{
    using System;
    using System.Linq;

    using Machine.Specifications;

    using Financial.Loan.Core.Model;
    using Financial.Loan.Core.Machine.Fakes;
    using Financial.Loan.Test;

    [Subject(typeof(ILoanQuoteController), "error conditions")]
    public class when_there_are_insufficient_lenders_to_statisfy_a_request_for_a_quote : WithConcreteSubject<ILoanQuoteController, LoanQuoteController>
    {
        Establish context = () => With( new OffersRepository(new[] { OfferTestData.BobsOffer, OfferTestData.JohnsOffer }));

        Because of = () => Exception = Catch.Exception(() => Subject.Prepare(1500M));

        It should_fail = () => Exception.ShouldNotBeNull();

        static Exception Exception;
    }

    [Subject(typeof(ILoanQuoteController), "calculating quotes")]
    public class when_there_are_sufficient_lenders_to_statisfy_a_request_for_a_quote : WithConcreteSubject<ILoanQuoteController, LoanQuoteController>
    {
        Establish context = () => With(new OffersRepository(new[] { OfferTestData.BobsOffer, OfferTestData.JohnsOffer }));

        Because of = () => Quote = Subject.Prepare(1000M);

        It should_not_fail = () => Quote.ShouldNotBeNull();

        It should_only_assign_the_amount_of_money_required_to_fulfil_the_loan_request = () => Quote.Lenders.Sum(item => item.AmountAssigned).ShouldEqual(1000);

        /*
         *  For this example there are two lenders Bob and John for a loan of 1000
         *   offering 640 @ 0.075 and 320 @0.081
         *  
         *  Therefore we borrow 640 @ 0.075 and 260 @ 0.081 over the 36 months
         * 
         *  Given periodic componded interest rate from wikipedia: http://en.wikipedia.org/wiki/Compound_interest#Compound
         * 
         *   A = P(1 + r/n) ^ (n * t)
         *   
         *   A = final amount
         *   P = principal amount (initial investment)
         *   r = annual nominal interest rate (as a decimal, not in percentage)
         *   n = number of times the interest is compounded per year
         *   t = number of years
         * 
         *   for the first portion this would equal = 640 * (1 + 0.075/12) ^ (12 * 3) gives us: 800.9255
         *   the second portion of 260 gives us: 458.6500
         *   giving a total repayment amount of: 1259.5756122554
         */
        It should_calculate_the_total_amount_using_montly_componded_interest = () => Quote.TotalRepayment.ShouldEqual(1259.57561225546000M);

        It should_calculate_the_monthly_repayment_amount = () => Quote.MonthlyRepayment.ShouldEqual(34.988211451540555555555555555556M);

        /*
         * r = (A / P) ^ (1 / t) - 1
         */
        It should_calculate_the_interest_rate_for_the_loan = () => Quote.Rate.ShouldEqual(0.079961021757252M);

        static ILoanQuote Quote;
    }

    [Subject(typeof(ILoanQuoteController), "calculating quotes")]
    public class when_preparing_a_quote_we_should_always_choose_from_the_best_offers_available : WithConcreteSubject<ILoanQuoteController, LoanQuoteController>
    {
        Establish context = () => With(new OffersRepository(new[] { OfferTestData.BobsOffer, OfferTestData.JohnsOffer, OfferTestData.BetterOfferThanJohn }));

        Because of = () => Quote = Subject.Prepare(1000M);

        It should_use_the_lowest_rate_offers_to_fulfil_the_requested_amount = () => Quote.Lenders.Select(item => item.Offer).ShouldNotContain(OfferTestData.JohnsOffer);

        static ILoanQuote Quote;
    }
}