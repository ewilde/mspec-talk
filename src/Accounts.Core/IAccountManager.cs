// -----------------------------------------------------------------------
// <copyright file="IAccountManager.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Accounts.Core
{
    public interface IAccountManager
    {
        void Transfer(Account source, Account target, decimal amount);

        /// <summary>
        /// Adds the specified value to the <see cref="Balance" />.
        /// </summary>
        /// <param name="target">The target account.</param>
        /// <param name="value">The value to add.</param>
        void Credit(Account target, decimal value);

        /// <summary>
        /// Debits the account by the specified value.
        /// </summary>
        /// <param name="target">The target account.</param>
        /// <param name="value">The value.</param>
        void Debit(Account target, decimal value);
    }
}