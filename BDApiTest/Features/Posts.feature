Feature: Posts
	In order to keep people informed of what I do
	As a user of this social service
	I want my posts to be posted correctly
	 
Scenario: Validate the response headers are returned correctly
	Given I request a post with id 1
	Then I ensure the server set response headers are correct

Scenario: Return the correct JSON body from the Post endpoint
	Given I request a post with id 1
	And I get a 200 response
	When I deserialise the "Post" response
	Then I can validate the "Post" response

Scenario: Empty JSON body is returned with invalid id for posts
	Given I request a post with id -1
	When I deserialise the "Post" response
	Then I can validate that the "Post" response is empty

Scenario: Ensure the response time is within acceptable limits
	Given I request a post with id -1
	Then I can check the response time is under 2000 milliseconds

	