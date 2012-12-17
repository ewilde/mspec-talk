// -----------------------------------------------------------------------
// <copyright file="CustomerFactory.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Accounts.Core
{
    using Accounts.Core;

    public class CustomerFactory
    {
        public static Customer CustomerWithSavingAndCurrentAccount()
        {
            return new Customer() {
                    Accounts = { 
                        new Account { Type = AccountType.Current}, 
                        new Account { Type = AccountType.Savings} }
                };
        }

        public static Customer CustomerWithSavingAndCurrentAccount(decimal? currentAccountCredit = null, decimal? savingsAccountCredit = null)
        {
            var customer = CustomerWithSavingAndCurrentAccount();

            if (currentAccountCredit.HasValue)
            {
                customer.CurrentAccount.Credit(currentAccountCredit.Value);
            }
            
            if (savingsAccountCredit.HasValue)
            {
                customer.SavingsAccount.Credit(savingsAccountCredit.Value);
            }

            return customer;
        }
    }
}