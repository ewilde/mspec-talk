// -----------------------------------------------------------------------
// <copyright file="AccountTransferSteps.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Account.Specs.Working.AccountsTransfer
{
    using Accounts.Core;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class AccountTransferSteps
    {
        Customer customer;



        [Given(@"the source account is sufficient with (\d+)m")]
        public void GivenTheSourceAccountIsSufficient(decimal amount)
        {
            customer = CustomerFactory.CustomerWithSavingAndCurrentAccount();
            customer.SavingsAccount.Credit(amount);
        }

        [Given(@"the source account is sufficient")]
        public void GivenTheSourceAccountIsSufficient()
        {
            customer = CustomerFactory.CustomerWithSavingAndCurrentAccount();
            customer.SavingsAccount.Credit(100m);
        }


        [Given(@"the customer has signed up to online banking")]
        public void GivenTheCustomerHasSignedUpToOnlineBanking()
        {
            customer.OnlineAccess = true;
        }

        [When(@"the customer transfers between accounts")]
        public void WhenTheCustomerTransfersBetweenAccounts()
        {
            customer.SavingsAccount.Transfer(customer.CurrentAccount, 100m);
        }

        [Then(@"the target account is credited immediately")]
        public void ThenTheTargetAccountIsCreditedImmediately()
        {
            Assert.That(customer.CurrentAccount.Balance, Is.EqualTo(100m));
        }

        [Then(@"the source account is debited immediately")]
        public void ThenTheSourceAccountIsDebitedImmediately()
        {
            Assert.That(customer.SavingsAccount.Balance, Is.EqualTo(0m));
        }
    }
}