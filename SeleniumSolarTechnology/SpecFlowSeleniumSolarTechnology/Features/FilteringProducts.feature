Feature: FilteringProducts

@mytag
Scenario: Filtering by Brand
	    Given Open Solartechnology Shop page
    And Open Solar Panels link
	    When Count product items before
	And Open filter by brands
    And Check Brand 'JA Solar'
    And Count product items after
        Then The count product items should be less than before

