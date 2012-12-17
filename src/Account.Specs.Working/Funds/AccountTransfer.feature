Feature: Account Transfer
	In order to avoid having to phone my bank
	As a customer
	I want to transfer money between my accounts

@Accounts
Scenario: Account has required funds
	Given the source account is sufficient
	And the customer has signed up to online banking
	When the customer transfers between accounts
	Then the target account is credited immediately
	And the source account is debited immediately

Scenario: Account has required funds2
	Given the source account is sufficient with 1000m
	And the customer has signed up to online banking
	When the customer transfers 100m between accounts
	Then the target account is 100m immediately
	And the source account is 900m immediately
