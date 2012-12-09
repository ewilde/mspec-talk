using System;

using Machine.Specifications;
using Rule.Financial.Loan.Core.Machine.Fakes;
using Rule.Financial.Loan.Core.Model;
using Rule.Financial.Loan.Core.ViewModel;

namespace Rule.Financial.Loan.Tests.UnitTests
{
    using Machine.Fakes;

    using Financial.Loan.Test;

    [Subject(typeof(StandardLoanQuoteViewModel), "display rules")]
    public class when_displaying_a_loan_quote_to_a_view : WithConcreteSubject<ILoanQuoteViewModel,StandardLoanQuoteViewModel>
    {
        Establish context = () =>
            {
                The<ILoanQuote>()
                    .WhenToldTo( x => x.TotalRepayment)
                    .Return(1259.5756122554M);

                The<ILoanQuote>()
                    .WhenToldTo( x => x.MonthlyRepayment)
                    .Return(34.9882114515M);

                The<ILoanQuote>()
                    .WhenToldTo( x => x.Rate)
                    .Return(0.079961021757252M);
                
                The<ILoanQuote>()
                    .WhenToldTo(x => x.RequestedAmount)
                    .Return(1000.00M);

                Subject.Quote = The<ILoanQuote>();
            };

        Because of = () => { };

        It should_display_total_repayment_to_two_decimal_places_with_the_currency_symbol = () => Subject.TotalRepayment.ShouldEqual("£1,259.58");

        It should_display_monthly_repayment_to_two_decimal_places_with_the_currency_symbol = () => Subject.MonthlyRepayment.ShouldEqual("£34.99");

        It should_disalay_the_rate_to_one_decimal_place_with_a_percent_sign_afterwards = () => Subject.Rate.ShouldEqual("8.0%");

        It should_disalay_the_requested_amount_to_zero_decimal_places_with_the_currency_symbol = () => Subject.RequestedAmount.ShouldEqual("£1,000");
    }
}