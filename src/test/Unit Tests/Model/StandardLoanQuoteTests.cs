// -----------------------------------------------------------------------
// <copyright file="QuoteTests.cs" company="Rule Financial">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------

using Rule.Financial.Loan.Core.Machine.Fakes;
using Rule.Financial.Loan.Core.Model;

namespace Rule.Financial.Loan.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Machine.Fakes;
    using Machine.Specifications;

    using Financial.Loan.Core.Machine.Fakes;
    using Financial.Loan.Core.Model;
    using Financial.Loan.Core.Utility;

    [Subject(typeof(ILoanQuote), "Loan quotes expected default values")]
    public class when_i_initialize_a_standard_quote_object : WithConcreteSubject<ILoanQuote, StandardLoanQuote>
    {
        Establish context = () => Configure( x => x.For<ILoanQuote>().Use<StandardLoanQuote>());
        
        It should_have_a_default_requested_amount_of_zero = () => Subject.RequestedAmount.ShouldEqual(0);

        It should_specify_a_rate_of_zero = () => Subject.Rate.ShouldEqual(0);

        It should_specify_a_monthly_repayment_of_zero = () => Subject.MonthlyRepayment.ShouldEqual(0);

        It should_specify_a_total_repayment_of_zero = () => Subject.TotalRepayment.ShouldEqual(0);

        It should_specify_a_repayment_term_of_36_months = () => Subject.RepaymentTermInMonths.ShouldEqual(36);

        It should_have_no_borrower = () => Subject.Borrower.ShouldBeNull();

        It should_have_no_lenders = () => Subject.Lenders.Count().ShouldEqual(0);

        It should_have_a_default_pound_sterling_currency_symbol = () => Subject.Currency.CurrencySymbol.ShouldEqual("£");

        It should_have_an_allowed_loan_increment_of_100_pounds = () => Subject.AllowedIncrement.ShouldEqual(100);

        It should_have_a_minimum_allowed_loan_request_of_1000 = () => Subject.MinimumLoanRequest.ShouldEqual(1000);

        It should_have_a_maximum_allowed_loan_request_of_15000 = () => Subject.MaximumLoanRequest.ShouldEqual(15000);
    }

    [Subject(typeof(ILoanQuote), "error conditions")]
    public class when_a_loan_is_set_above_the_maximum_allowed_amount : WithConcreteSubject<ILoanQuote, StandardLoanQuote>
    {
        Because of = () => Exception = Catch.Exception(() => Subject.RequestedAmount = 15000.1M);

        It should_fail = () => Exception.ShouldNotBeNull();

        static Exception Exception;
    }

    [Subject(typeof(ILoanQuote), "error conditions")]
    public class when_a_loan_is_set_below_the_minimum_allowed_amount : WithConcreteSubject<ILoanQuote, StandardLoanQuote>
    {
        Because of = () => Exception = Catch.Exception(() => Subject.RequestedAmount = 999.99M);

        It should_fail = () => Exception.ShouldNotBeNull();

        static Exception Exception;
    }

    [Subject(typeof(ILoanQuote), "error conditions")]
    public class when_a_loan_is_set_using_an_increment_other_than_that_allowed_ : WithConcreteSubject<ILoanQuote, StandardLoanQuote>
    {
        Because of = () => Exception = Catch.Exception(() => Subject.RequestedAmount = 1505M);

        It should_fail = () => Exception.ShouldNotBeNull();

        static Exception Exception;
    }
}


