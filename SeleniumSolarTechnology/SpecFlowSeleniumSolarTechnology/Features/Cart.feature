Feature: Cart

@mytag
Scenario: Add and remove products from cart
	    Given Open Solartechnology Shop page
    And Open Cable And Switching link
	    When Add product item to cart(1)
	And Make order
    And Remove product item from cart(0)
        Then There must be a return to the Home page

     

        