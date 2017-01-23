Feature: ContactUs
	Navigate to Contact Us page
	Fill in the form
	Submit the form

@Browser:Chrome
@Browser:Firefox
Scenario: Location is mandotary field By Imperative 
	Given I am at the Home Page
	And I navigate to ContactUs Page
	When I fill in First Name as Emily
	And I fill in Last Name as West
	And I fill in Job Title as Test Analyst
	And I fill in Organisation as Planit
	And I fill in Phone as 0211569987
	And I fill in Email as test@test.com
	And I press Submit Button
	Then I can see Please enter your Location message display

@Browser:Chrome 
@Browser:Firefox
Scenario: Location is mandotary field By Declarative 
	Given I am at the Home Page
	And I navigate to ContactUs Page
	When I Fill the contact information form with correct information
	And I press Submit Button
	Then I can see error message display

@Browser:Chrome
@Browser:Firefox
Scenario: Location is mandotary field with Data Driven
	Given I am at the Home Page
	And I navigate to ContactUs Page
	When I Fill the contact information form with
	| firstname | lastname | jobtitle      | organisation | phone      | email               |
	| Helen     | West     | Test Analyst | Planit      | 0210581977 | lyi@planittesting.com |
	And I press Submit Button
	Then I can see error message display

@Browser:Chrome
Scenario: Successfuly to set failure status in test report
	Given I am at the Home Page
	And I navigate to ContactUs Page
	When I Fill the contact information form with
	| firstname | lastname | jobtitle      | organisation | phone      | email               |
	| Helen     | West     | Test Analyst | Planit      | 0210581977 | lyi@planittesting.com |
	And I press Submit Button
	Then I can see it successfully submit the contact information

@Browser:Chrome
Scenario: Location is mandotary field with Pending
	Given I am at the Home Page
	And I navigate to ContactUs Page
	When I want to try pending status in test report
	Then I can see the pending result
