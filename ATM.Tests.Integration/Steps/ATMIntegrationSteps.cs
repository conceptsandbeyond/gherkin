using ATM.CredentialCheck;
using ATM.CheckBalance;
using ATM.DebitAmount;
using ATM.CreditAmount;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ATM.Tests.Integration
{
    [Binding]
    public class ATMIntegrationSteps
    {
        private string _cardNumber;
        private string _pin;
        private bool _isAuthenticated;
        private decimal _initialBalance;
        private decimal _currentBalance;
        private CredentialService _credentialService;
        private BalanceService _balanceService;
        private DebitService _debitService;
        private CreditService _creditService;

        [Given(@"I have a card number ""(.*)""")]
        public void GivenIHaveACardNumber(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        [Given(@"I have a PIN ""(.*)""")]
        public void GivenIHaveAPIN(string pin)
        {
            _pin = pin;
        }

        [Given(@"I have a balance of (.*)")]
        public void GivenIHaveABalanceOf(decimal balance)
        {
            _initialBalance = balance;
            _balanceService = new BalanceService(_initialBalance);
            _debitService = new DebitService(_initialBalance);
            _creditService = new CreditService(_initialBalance);
        }

        [When(@"I validate the credentials")]
        public void WhenIValidateTheCredentials()
        {
            _credentialService = new CredentialService();
            _isAuthenticated = _credentialService.ValidateCredentials(_cardNumber, _pin);
            Assert.IsTrue(_isAuthenticated, "Authentication failed");
        }

        [When(@"I check the balance")]
        public void WhenICheckTheBalance()
        {
            _currentBalance = _balanceService.GetBalance();
            Assert.AreEqual(_initialBalance, _currentBalance, "Initial balance mismatch");
        }

        [When(@"I debit (.*)")]
        public void WhenIDebit(decimal amount)
        {
            var success = _debitService.Debit(amount);
            if (success)
            {
                _currentBalance = _debitService.GetBalance();
                // Update the balance in other services to maintain consistency
                _balanceService.SetBalance(_currentBalance);
                _creditService.SetBalance(_currentBalance);
            }
            else
            {
                Assert.Fail("Debit operation failed due to insufficient funds");
            }
        }

        [When(@"I credit (.*)")]
        public void WhenICredit(decimal amount)
        {
            _creditService.Credit(amount);
            _currentBalance = _creditService.GetBalance();
            // Update the balance in other services to maintain consistency
            _balanceService.SetBalance(_currentBalance);
            _debitService.SetBalance(_currentBalance);
        }

        [Then(@"the balance should be (.*)")]
        public void ThenTheBalanceShouldBe(decimal expectedBalance)
        {
            Assert.That(_currentBalance,Is.EqualTo(expectedBalance));
        }
    }
}
