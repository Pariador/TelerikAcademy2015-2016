namespace BankAccApp
{
    using System;

    public class MortgageAcc : Account, IDeposit
    {
        public MortgageAcc(Customer customer, decimal interestRate) : base(customer, interestRate)
        {
            ;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance < 0)
            {
                throw new ApplicationException("Can't CalculateInterest account balance is negative.");
            }

            decimal balance = this.Balance;
            decimal totalInterest = 0.00M;

            for (int c = 0; c < months; c++)
            {
                if (this.AccCustomer.Type == CustomerType.Individual && c < 6)
                {
                    continue;
                }

                decimal monthInterest = (balance / 100) * this.InterestRate;

                if (this.AccCustomer.Type == CustomerType.Company && c < 12)
                {
                    monthInterest *= 0.5M;
                }

                balance += monthInterest;
                totalInterest += monthInterest;
            }

            return totalInterest;
        }
    }
}