using System;

using Machine.Fakes;
using Machine.Specifications;
using Rule.Financial.Loan.Console;
using Rule.Financial.Loan.Core.Model;
using Rule.Financial.Loan.Core.Services;
using Rule.Financial.Loan.Test;

namespace Rule.Financial.Loan.Tests.UnitTests
{
    using Financial.Loan.Core.Model;
    using Financial.Loan.Core.Services;
    using Financial.Loan.Test;

    [Subject(typeof(RateCalulator))]
    public class when_calculating_a_quote_with_sufficient_lenders_using_the_rate_calculator : WithSubject<RateCalulator>
    {
        Establish context = () => With(new StandardFakeLoanController(1000M, 0.08M, 30.5M, 1200M));

        Because of = () => Subject.Calculate(1000M);

        It should_call_the_loan_controller_calculate_method = () => The<ILoanQuoteController>().WasToldTo(call => call.Prepare(1000));

        It should_write_a_success_message_to_the_console_composing_of_4_parts = () => The<IConsoleWriter>().WasToldTo(call => call.WriteInformation(Param<string>.IsAnything)).Times(4);
    }

    [Subject(typeof(RateCalulator))]
    public class when_calculating_a_quote_with_insufficient_lenders_using_the_rate_calculator : WithSubject<RateCalulator>
    {
        Establish context = () => With(new StandardFakeLoanController(1000M, 0.08M, 30.5M, 1200M, throwExceptionOnPrepare: true));

        Because of = () => Subject.Calculate(1000M);

        It should_call_the_loan_controller_calculate_method = () => The<ILoanQuoteController>().WasToldTo(call => call.Prepare(1000));

        It should_write_an_error_message_to_the_console = () => The<IConsoleWriter>().WasToldTo(call => call.WriteError(Param<string>.IsAnything));
    }
}