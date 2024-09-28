namespace ATM.DebitAmount
{
    public class DebitService
    {
        private decimal _balance;

        public DebitService(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        public bool Debit(decimal amount)
        {
            if (amount > _balance)
            {
                return false;
            }
            _balance -= amount;
            return true;
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
