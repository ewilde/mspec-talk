// -----------------------------------------------------------------------
// <copyright file="Customer.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------
namespace Accounts.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Caliburn.Micro;

    public class Customer : PropertyChangedBase
    {
        public Customer()
        {
            this.Accounts = new List<Account>();
        }

        public Customer(IRepository<Customer> repository) : this()
        {
            Repository = repository;
        }

        public List<Account> Accounts { get; set; }

        public IRepository<Customer> Repository { get; set; }

        public Account SavingsAccount
        {
            get
            {
                return this.Accounts.First(item => item.Type == AccountType.Savings);
            }
        }

        public Account CurrentAccount
        {
            get
            {
                return this.Accounts.First(item => item.Type == AccountType.Current);
            }
        }

        public bool OnlineAccess { get; set; }

        public void Save()
        {
            this.Repository.Save();
        }
    }
}