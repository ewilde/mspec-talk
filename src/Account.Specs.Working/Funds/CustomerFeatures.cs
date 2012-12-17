// -----------------------------------------------------------------------
// <copyright file="CustomerFeatures.cs" company="UBS AG">
// Copyright (c) 2012.
// </copyright>
// -----------------------------------------------------------------------


using System;

using Machine.Fakes;
using Machine.Specifications;

namespace Account.Specs.Working.Funds
{
    using System.Diagnostics;

    using Accounts.Core;

    [Subject(typeof(Customer))]
    public class When_a_customer_transfers_money_between_accounts
    {
        Establish context = () => customer = CustomerFactory.CustomerWithSavingAndCurrentAccount(savingsAccountCredit:100m);

        Because of = () => customer.SavingsAccount.Transfer(customer.CurrentAccount, 100m);

        It should_debit_the_saving_account = () => customer.SavingsAccount.Balance.ShouldEqual(0m);

        It should_credit_the_current_account = () => customer.CurrentAccount.Balance.ShouldEqual(100m);

        Behaves_like<CustomerWithACurrentAccountInCredit> a_customer_with_a_current_account_in_credit = () => { };                         

        
        protected static Customer customer;
    }

    [Behaviors]
    public class CustomerWithACurrentAccountInCredit
    {
        protected static Customer customer;

        It should_have_a_current_account_in_credit = () => customer.CurrentAccount.Balance.ShouldBeGreaterThan(0m);
    }
    
    public class When_a_customer_object_is_saved : WithFakes
    {
        protected static Customer customer;

        Establish context = () =>
                customer = new Customer(An<IRepository<Customer>>());

        Because of = () => customer.Save();

        It should_call_the_repository_save_method = () => customer.Repository.WasToldTo(x=>x.Save());
    }

    public class When_persisting_a_customer_record : WithSubject<Customer>
    {
        Because of = () => Subject.Save();

        It should_call_the_repository_save_method = () => Subject.Repository.WasToldTo(x=>x.Save());
    }


    public class When_persisting_customer_data_during_database_down_time : WithSubject<Customer>
    {
        Establish context = () => With<RepositoryDown<Customer>>();

        Because of = () => Exception = Catch.Exception(()=>Subject.Save());

        It should_fail = () => Exception.ShouldNotBeNull();        

        static Exception Exception;
    }

    public class RepositoryDown<T>
    {
        OnEstablish context = fake =>
            {
                fake.The<IRepository<T>>().WhenToldTo(x=>x.Save()).Throw(new Exception());
            };

        OnCleanup test_data = test => { Debug.WriteLine(test); };
    }
}