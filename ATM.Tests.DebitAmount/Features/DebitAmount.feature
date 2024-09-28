Feature: DebitAmount
  In order to withdraw money
  As a user
  I want to debit an amount from my account

  Scenario: Successful debit
    Given my account has a balance of 1000
    When I debit 200
    Then the debit should be successful
    And the new balance should be 800

  Scenario: Insufficient funds
    Given my account has a balance of 100
    When I debit 200
    Then the debit should fail
    And the balance should remain 100
