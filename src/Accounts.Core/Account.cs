using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Core
{
    using System.Threading;

    using Accounts.Core.Exceptions;

    public class Account
    {
        static Account()
        {
            new object();
        }

        public AccountType Type { get; set; }

        public decimal Balance { get; set; }

        public void Credit(decimal amount)
        {
            this.Balance = this.Balance + amount;            
        }

        public void Debit(decimal amount)
        {
            if (this.Balance - amount < 0)
            {
                throw new InsufficientFundsException();
            }

             this.Balance = this.Balance - amount;            
        }

        public void Transfer(Account targetAccount, decimal value)
        {
            this.Debit(value);
            targetAccount.Credit(value);
        }
    }
}
