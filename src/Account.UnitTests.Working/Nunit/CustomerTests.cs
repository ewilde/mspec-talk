// -----------------------------------------------------------------------
// <copyright file="CustomerTests.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Accounts.UnitTests.Nunit
{
    using Accounts.Core;

    using NUnit.Framework;

    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void transfering_money_between_account_with_sufficient_funds_should_credit_target_account()
        {
            Customer customer = CustomerFactory.CustomerWithSavingAndCurrentAccount(currentAccountCredit: 0m, savingsAccountCredit: 100m);

            customer.SavingsAccount.Transfer(customer.CurrentAccount, 100m);

            Assert.That(customer.CurrentAccount.Balance, Is.EqualTo(100m));
        }
    }
}