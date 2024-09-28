namespace ATM.CheckBalance
{
    public class BalanceService
    {
        private decimal _balance;

        public BalanceService(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        // Optionally, add a method to set the balance for integration purposes
        public void SetBalance(decimal newBalance)
        {
            _balance = newBalance;
        }
    }
}
