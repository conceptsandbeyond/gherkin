using ATM.CheckBalance;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ATM.Tests.CheckBalance
{
    [Binding]
    public class CheckBalanceSteps
    {
        private decimal _initialBalance;
        private decimal _currentBalance;
        private BalanceService _balanceService;

        [Given(@"my account has a balance of (.*)")]
        public void GivenMyAccountHasABalanceOf(decimal balance)
        {
            _initialBalance = balance;
            _balanceService = new BalanceService(_initialBalance);
        }

        [When(@"I check the balance")]
        public void WhenICheckTheBalance()
        {
            _currentBalance = _balanceService.GetBalance();
        }

        [Then(@"the balance should be (.*)")]
        public void ThenTheBalanceShouldBe(decimal expectedBalance)
        {
            Assert.That(_currentBalance,Is.EqualTo(expectedBalance));
        }
    }
}
