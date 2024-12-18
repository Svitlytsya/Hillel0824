Feature: ExistingUserTests

@login
Scenario: CheckoutAsExistingUser
	Given open home page
	And open My account
	When open Order History
	Then there are some Orders

