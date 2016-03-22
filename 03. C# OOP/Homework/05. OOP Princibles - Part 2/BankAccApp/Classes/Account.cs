namespace BankAccApp
{
    using System;

    public abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        protected Account(Customer customer, decimal interestRate)
        {
            this.AccCustomer = customer;
            this.Balance = 0.00M;
            this.InterestRate = interestRate;
        }

        public Customer AccCustomer
        {
            get
            {
                return this.customer;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException("AccCustomer can't be null.");
                }

                this.customer = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            protected set
            {
                this.balance = value;
            }
        }
        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Account InterestRate can'be less than 0 or more than 100.");
                }

                this.interestRate = value;
            }
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (this.Balance < 0)
            {
                throw new ApplicationException("Can't CalculateInterest account balance is negative.");
            }

            decimal balance = this.Balance;
            decimal totalInterest = 0.00M;

            for (int c = 0; c < months; c++)
            {
                decimal monthInterest = (balance / 100) * this.InterestRate;
                balance += monthInterest;
                totalInterest += monthInterest;
            }

            return totalInterest;
        }
    }
}