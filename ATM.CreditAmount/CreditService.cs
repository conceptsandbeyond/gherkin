namespace ATM.CreditAmount
{
    public class CreditService
    {
        private decimal _balance;

        public CreditService(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        public void Credit(decimal amount)
        {
            _balance += amount;
        }

        public decimal GetBalance()
        {
            return _balance;
        }
        public void SetBalance(decimal newBalance)
        {
            _balance = newBalance;
        }
    }
}
