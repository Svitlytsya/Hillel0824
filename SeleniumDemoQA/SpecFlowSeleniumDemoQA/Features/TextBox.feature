Feature: TextBox

@mytag
Scenario: Fill form with valid data
	     Given Open Text Box page
	
	    When Fill Full Name 'Dog Pulya'
    And Fill Email 'pulyadog@gmail.com'
    And Fill Current Address 'Varash city, Budivelnikiv street, building 3, apartment 333'
    And Fill Permanent Address '03549,Kyiv city, Zhylyanska street, building 1, apartment 111'
    And Submit Form
	 
		Then Output Name should be 'Name:Dog Pulya'