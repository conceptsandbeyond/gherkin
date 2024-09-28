namespace ATM.CredentialCheck
{
    public class CredentialService
    {
        // For simplicity, using a hardcoded card number and PIN.
        // In a real-world application, this should be securely stored and managed.
        private readonly string _validCardNumber = "1234567890123456";
        private readonly string _validPin = "1234";

        public bool ValidateCredentials(string cardNumber, string pin)
        {
            return cardNumber == _validCardNumber && pin == _validPin;
        }
    }
}
