namespace BankAccApp
{
    public class Customer
    {
        private static int nextID = 1;
        private string name;

        public Customer(string name, CustomerType type)
        {
            this.Name = name;
            this.Type = type;
            this.CustomerID = Customer.NextID;
        }

        private static int NextID
        {
            get
            {
                return Customer.nextID++;
            }
        }
        public int CustomerID { get; private set; }
        public CustomerType Type { get; set; }
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

        public override string ToString()
        {
            return this.Name;
        }
    }
}