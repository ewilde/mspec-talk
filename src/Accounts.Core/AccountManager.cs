// -----------------------------------------------------------------------
// <copyright file="AccountManager.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Accounts.Core
{
    public class AccountManager : IAccountManager
    {
        private static readonly object syncRoot;

        static AccountManager()
        {
            syncRoot = new object();
        }

        public void Transfer(Account source, Account target, decimal amount)
        {
            this.Debit(source, amount);
            this.Credit(target, amount);
        }

        /// <summary>
        /// Adds the specified value to the <see cref="Account.Balance" />.
        /// </summary>
        /// <param name="target">The target account.</param>
        /// <param name="value">The value to add.</param>
        public void Credit(Account target, decimal value)
        {
            lock (syncRoot)
            {
                target.Balance = target.Balance + value;
            }
        }

        /// <summary>
        /// Debits the account by the specified value.
        /// </summary>
        /// <param name="target">The target account.</param>
        /// <param name="value">The value.</param>
        public void Debit(Account target, decimal value)
        {
            lock (syncRoot)
            {
                target.Balance = target.Balance - value;
            }
        }
    }
}