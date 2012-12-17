Feature: Accounts transfer
	In order to avoid calling the bank to make a transfer
	As a customer
	I want to move money between accounts online

@accounts
Scenario:	Account has required funds
Given the source account is sufficient
And the customer has signed up to online banking
When the customer transfers money between accounts
Then the target account is credited immediately
And the source account is debited immediately

@accounts
Scenario:	Current account has required funds
Given the savings account has 100 pounds
And the current account has 10 pounds
And the customer has signed up to online banking
When the customer transfers 100 pounds between their savings account to their current account
Then the current account total is 110 pounds
And the savings account totatl is 0 pounds


