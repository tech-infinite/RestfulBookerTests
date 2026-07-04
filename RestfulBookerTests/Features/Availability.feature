Feature: Check room availability

  As a new booking user
  I want to see which rooms are available
  So that I can book a suitable room quickly

  Background: 
	Given I am on the hotel home page

  Scenario: Search for available rooms using valid dates
    When I select a valid check-in date
    And I select a valid check-out date
    And I search for available rooms
    Then I should see a list of available rooms

  Scenario: No rooms available
    When I search using dates with no availability
    Then I should see a "No rooms available" message
