using ATM.CreditAmount;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ATM.Tests.CreditAmount
{
    [Binding]
    public class CreditAmountSteps
    {
        private decimal _initialBalance;
        private decimal _creditAmount;
        private decimal _newBalance;
        private CreditService _creditService;

        [Given(@"my account has a balance of (.*)")]
        public void GivenMyAccountHasABalanceOf(decimal balance)
        {
            _initialBalance = balance;
            _creditService = new CreditService(_initialBalance);
        }

        [When(@"I credit (.*)")]
        public void WhenICredit(decimal amount)
        {
            _creditAmount = amount;
            _creditService.Credit(_creditAmount);
            _newBalance = _creditService.GetBalance();
        }

        [Then(@"the new balance should be (.*)")]
        public void ThenTheNewBalanceShouldBe(decimal expectedBalance)
        {
            Assert.That( _newBalance, Is.EqualTo(expectedBalance));
        }
    }
}
