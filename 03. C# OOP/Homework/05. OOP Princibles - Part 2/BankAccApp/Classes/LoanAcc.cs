namespace BankAccApp
{
    using System;

    public class LoanAcc : Account, IDeposit
    {
        public LoanAcc(Customer customer, decimal interestRate) : base(customer, interestRate)
        {
            ;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(int months)
        {
            switch (this.AccCustomer.Type)
            {
                case CustomerType.Individual:
                    return base.CalculateInterest(months - 3);
                case CustomerType.Company:
                    return base.CalculateInterest(months - 2);
                default:
                    throw new ApplicationException("Error LoanAcc - CalculateInterese - Switch.");
            }
        }
    }
}