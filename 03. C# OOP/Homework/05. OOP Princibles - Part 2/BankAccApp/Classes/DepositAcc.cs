namespace BankAccApp
{
    using System;

    public class DepositAcc : Account, IDeposit, IWithdraw
    {
        public DepositAcc(Customer customer, decimal interestRate) : base(customer, interestRate)
        {
            ;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance < 1000)
            {
                return 0.00M;
            }
            else
            {
               return base.CalculateInterest(months);
            }
        }
    }
}