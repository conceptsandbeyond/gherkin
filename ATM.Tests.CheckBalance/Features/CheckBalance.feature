Feature: CheckBalance
  In order to view my account balance
  As a user
  I want to check my current balance

  Scenario: Check balance with initial amount
    Given my account has a balance of 1000
    When I check the balance
    Then the balance should be 1000
