Feature: Cart

@mytag
Scenario: Add and remove products from cart
    Given Open Solartechnology Shop page
        And Open Cable And Switching link
    When Add second product item from catalog to cart
	    And Make order
        And Remove first product item from cart
    Then There must be a return to the Home page

     

        