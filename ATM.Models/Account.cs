// Models/Account.cs
namespace ATM.Models
{
    public class Account
    {
        public string CardNumber { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }

        public Account(string cardNumber, string pin, decimal initialBalance)
        {
            CardNumber = cardNumber;
            Pin = pin;
            Balance = initialBalance;
        }
    }
}
