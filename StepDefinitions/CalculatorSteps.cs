using TechTalk.SpecFlow;
using Xunit;

namespace IntegrationTests.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        private int _firstNumber;
        private int _secondNumber;
        private int _result;
        private Calculator _calculator;

        public CalculatorSteps()
        {
            _calculator = new Calculator();
        }

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _firstNumber = number;
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _secondNumber = number;
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add(_firstNumber, _secondNumber);
        }

        [When(@"the second number is subtracted from the first number")]
        public void WhenTheSecondNumberIsSubtractedFromTheFirstNumber()
        {
            _result = _calculator.Subtract(_firstNumber, _secondNumber);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            Assert.Equal(expectedResult, _result);
        }
    }
}
