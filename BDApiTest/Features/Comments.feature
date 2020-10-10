Feature: Comments
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Return a valid JSON response from the Comments API
	Given I request a comment with id 1
	And I get a 200 response
	When I deserialise the "Comments" response
	Then I can validate the "Comments" response

Scenario: Empty JSON body is returned with invalid id for Comments
	Given I request a comment with id -1
	When I deserialise the "Comments" response
	Then I can validate that the "Comments" response is empty
