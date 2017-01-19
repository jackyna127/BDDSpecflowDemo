Feature: Search
	Search Website


@Browser:Chrome
@Browser:Firefox
Scenario: Search in the website
	Given I am at the Home Page
	And I have entered search content
	| searchcontent |
	| Automation    |
	When I press search button
	Then The result should be displayed on the screen

