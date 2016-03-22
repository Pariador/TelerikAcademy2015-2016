namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Common;
    using Contracts;

    public abstract class Product : IProduct
    {
        protected const int MinNameLength = 3;
        protected const int MaxNameLength = 10;
        protected const int MinBrandLength = 2;
        protected const int MaxBrandLength = 10;

        private string name;
        private string brand;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                CustomValidator.StrInRangeAndNotNullOrEmpty(value, Product.MinNameLength, Product.MaxNameLength, "Product name");

                this.name = value;
            }
        }
        public virtual string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {
                CustomValidator.StrInRangeAndNotNullOrEmpty(value, Product.MinBrandLength, Product.MaxBrandLength, "Product brand");

                this.brand = value;
            }
        }
        public virtual decimal Price
        {
            get;
            protected set;
        }
        public GenderType Gender
        {
            get;
            protected set;
        }

        public virtual string Print()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format("  * Price: ${0}", this.Price));
            result.Append(string.Format("  * For gender: {0}", this.Gender));

            return result.ToString();
        }
    }
}