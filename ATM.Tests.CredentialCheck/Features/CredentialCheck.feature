Feature: CredentialCheck
  In order to access the ATM
  As a user
  I want to validate my card number and PIN

  Scenario: Valid card and PIN
    Given I have a card number "1234567890123456"
    And I have a PIN "1234"
    When I validate the credentials
    Then the validation should be successful

  Scenario: Invalid card number
    Given I have a card number "0000000000000000"
    And I have a PIN "1234"
    When I validate the credentials
    Then the validation should fail

  Scenario: Invalid PIN
    Given I have a card number "1234567890123456"
    And I have a PIN "0000"
    When I validate the credentials
    Then the validation should fail

  Scenario: Both card number and PIN are invalid
    Given I have a card number "0000000000000000"
    And I have a PIN "0000"
    When I validate the credentials
    Then the validation should fail
