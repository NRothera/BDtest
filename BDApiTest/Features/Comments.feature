Feature: Comments
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Get Comments
	Given I request a comment with id 1
	When I deserialise the "Comments" response
	Then I can validate the response