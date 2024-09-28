Feature: CreditAmount
  In order to deposit money
  As a user
  I want to credit an amount to my account

  Scenario: Successful credit
    Given my account has a balance of 1000
    When I credit 200
    Then the new balance should be 1200
