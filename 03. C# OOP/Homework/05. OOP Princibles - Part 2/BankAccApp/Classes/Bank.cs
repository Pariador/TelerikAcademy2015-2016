namespace BankAccApp
{
    using System;
    using System.Collections.Generic;
    public class Bank
    {
        private string name;

        public Bank(string name)
        {
            this.Name = name;
            this.Accounts = new List<Account>();
        }

        public List<Account> Accounts { get; private set; }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                value = value.Trim();

                if (string.IsNullOrEmpty(value) || value.Length > 30)
                {
                    throw new NameException();
                }

                this.name = value;
            }
        }
    }
}