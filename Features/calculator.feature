Feature: Calculator Operations
  In order to avoid mistakes
  As a math user
  I want to use a calculator to perform addition and subtraction

  Scenario: Add two numbers
    Given the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

  Scenario: Subtract two numbers
    Given the first number is 100
    And the second number is 40
    When the second number is subtracted from the first number
    Then the result should be 60
