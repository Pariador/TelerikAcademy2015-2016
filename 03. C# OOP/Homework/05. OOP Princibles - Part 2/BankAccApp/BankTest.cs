namespace BankAccApp
{
    using System;

    public static class BankTest
    {
        public static void Start()
        {
            Bank myBank = new Bank("MyBank");

            myBank.Accounts.Add(new LoanAcc(new Customer("John", CustomerType.Individual), 1.4M));
            (myBank.Accounts[0] as LoanAcc).Deposit(528);

            myBank.Accounts.Add(new MortgageAcc(new Customer("Jane", CustomerType.Individual), 1.6M));
            (myBank.Accounts[1] as MortgageAcc).Deposit(582);

            myBank.Accounts.Add(new DepositAcc(new Customer("J&J", CustomerType.Company), 2.0M));
            (myBank.Accounts[2] as DepositAcc).Deposit(3242);

            foreach (var acc in myBank.Accounts)
            {
                Console.WriteLine(acc.AccCustomer.Name);
                Console.WriteLine("{0:0.00}", acc.CalculateInterest(7));
            }
        }
    }
}