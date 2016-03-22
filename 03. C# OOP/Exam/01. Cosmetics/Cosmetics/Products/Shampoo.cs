namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Contracts;

    public class Shampoo : Product, IShampoo, IProduct
    {
        public Shampoo(string name, string brand, decimal pricePerMl, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, 0.00M, gender)
        {
            this.PricePerMl = pricePerMl;
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public override decimal Price
        {
            get
            {
                return this.PricePerMl * this.Milliliters;
            }
        }
        public decimal PricePerMl { get; private set; }

        public uint Milliliters
        {
            get;
            protected set;
        }
        public UsageType Usage
        {
            get;
            protected set;
        }

        public override string Print()
        {
            var result = new StringBuilder();

            result.AppendLine(base.Print());
            result.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            result.Append(string.Format("  * Usage: {0}", this.Usage));
            
            return result.ToString();
        }
    }
}