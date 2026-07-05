Feature: Admin authentication

  As an admin
  I want to authenticate successfully
  So that only authorised users can access the system

  Background: 
	Given I am on the admin login page

  Scenario: Successful login
    #Given valid admin credentials
    When I submit a login request
    Then the API should return HTTP 200
    And an authentication token should be returned

  Scenario: Invalid login
   # Given invalid admin credentials
    When I submit a login request
    Then authentication should fail
