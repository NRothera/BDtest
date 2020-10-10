Feature: Posts
	In order to test that posts are correctly formatted
	As a 
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Return a valid JSON response from the Post API
	Given I request a post with id 2
	And I get a 200 response
	When I deserialise the "Post" response
	Then I can validate the "Post" response

Scenario: Empty JSON body is returned with invalid id for posts
	Given I request a post with id -1
	When I deserialise the "Post" response
	Then I can validate that the "Post" response is empty