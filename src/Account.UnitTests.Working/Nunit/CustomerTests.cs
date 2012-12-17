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
        public void Transfering_money_between_accounts_when_in_credit()
        {
            Customer customer = CustomerFactory.CustomerWithSavingAndCurrentAccount();
        
            customer.SavingsAccount.Transfer(customer.CurrentAccount, 100m);

            Assert.That(customer.CurrentAccount.Balance, Is.EqualTo(100m));
        }
    }
}