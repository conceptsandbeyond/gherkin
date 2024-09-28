Feature: ATM Integration
  In order to perform multiple operations
  As a user
  I want to use all ATM functionalities together

  Scenario: User logs in, checks balance, debits and credits
    Given I have a card number "1234567890123456"
    And I have a PIN "1234"
    And I have a balance of 1000
    When I validate the credentials
    And I check the balance
    And I debit 200
    And I credit 500
    Then the balance should be 1300
