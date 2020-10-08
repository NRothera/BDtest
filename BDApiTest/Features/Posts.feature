Feature: Posts
	In order to test that posts are correctly formatted
	As a 
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Get Posts
	Given I request a post with id 1
	When I deserialise the "Post" response
	Then I can validate the response