using ATM.CredentialCheck;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ATM.Tests.CredentialCheck
{
    [Binding]
    public class CredentialCheckSteps
    {
        private string _cardNumber;
        private string _pin;
        private bool _result;
        private CredentialService _credentialService;

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

        [When(@"I validate the credentials")]
        public void WhenIValidateTheCredentials()
        {
            _credentialService = new CredentialService();
            _result = _credentialService.ValidateCredentials(_cardNumber, _pin);
        }

        [Then(@"the validation should be successful")]
        public void ThenTheValidationShouldBeSuccessful()
        {
            Assert.IsTrue(_result);
        }

        [Then(@"the validation should fail")]
        public void ThenTheValidationShouldFail()
        {
            Assert.IsFalse(_result);
        }
    }
}
