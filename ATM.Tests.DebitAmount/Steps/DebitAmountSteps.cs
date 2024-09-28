using ATM.DebitAmount;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ATM.Tests.DebitAmount
{
    [Binding]
    public class DebitAmountSteps
    {
        private decimal _initialBalance;
        private decimal _debitAmount;
        private bool _result;
        private decimal _newBalance;
        private DebitService _debitService;

        [Given(@"my account has a balance of (.*)")]
        public void GivenMyAccountHasABalanceOf(decimal balance)
        {
            _initialBalance = balance;
            _debitService = new DebitService(_initialBalance);
        }

        [When(@"I debit (.*)")]
        public void WhenIDebit(decimal amount)
        {
            _debitAmount = amount;
            _result = _debitService.Debit(_debitAmount);
            _newBalance = _debitService.GetBalance();
        }

        [Then(@"the debit should be successful")]
        public void ThenTheDebitShouldBeSuccessful()
        {
            Assert.IsTrue(_result);
        }

        [Then(@"the new balance should be (.*)")]
        public void ThenTheNewBalanceShouldBe(decimal expectedBalance)
        {
            Assert.That(_newBalance,Is.EqualTo(expectedBalance));
        }

        [Then(@"the debit should fail")]
        public void ThenTheDebitShouldFail()
        {
            Assert.IsFalse(_result);
        }

        [Then(@"the balance should remain (.*)")]
        public void ThenTheBalanceShouldRemain(decimal expectedBalance)
        {
            Assert.That(_newBalance,Is.EqualTo(expectedBalance));
        }
    }
}
