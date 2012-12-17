// -----------------------------------------------------------------------
// <copyright file="AccountsSteps.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Accounts.Specs.Accounts
{
    using Moq;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    using global::Accounts.Core;

    [Binding]
    public class AccountSteps
    {
        Customer customer;

        [Given(@"the source account is sufficient")]
        public void GivenTheSourceAccountIsSufficient()
        {
            customer = CustomerFactory.CustomerWithSavingAndCurrentAccount(currentAccountCredit: 0m, savingsAccountCredit:100m);
        }

        [Given(@"the customer has signed up to online banking")]
        public void GivenTheCustomerHasSignedUpToOnlineBanking()
        {
            customer.OnlineAccess = true;
        }

        [Given(@"the savings account has (.*) pounds")]
        public void GivenTheSavingsAccountHasPounds(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the current account has (.*) pounds")]
        public void GivenTheCurrentAccountHasPounds(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        

        [When(@"the customer transfers money between accounts")]
        public void WhenTheCustomerTransfersMoneyBetweenAccounts()
        {
            customer.SavingsAccount.Transfer(customer.CurrentAccount, 200m);
        }

        [Then(@"the target account is credited immediately")]
        public void ThenTheTargetAccountIsCreditedImmediately()
        {
            Assert.That(customer.CurrentAccount.Balance, Is.EqualTo(100m));
        }

        [Then(@"the source account is debited immediately")]
        public void ThenTheSourceAccountIsDebitedImmediately()
        {
            Assert.That(customer.SavingsAccount.Balance.Equals(0));
        }

        
        [When(@"the customer transfers (.*) pounds between their savings account to their current account")]
        public void WhenTheCustomerTransfersPoundsBetweenTheirSavingsAccountToTheirCurrentAccount(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the current account total is (.*) pounds")]
        public void ThenTheCurrentAccountTotalIsPounds(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the savings account totatl is (.*) pounds")]
        public void ThenTheSavingsAccountTotatlIsPounds(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}