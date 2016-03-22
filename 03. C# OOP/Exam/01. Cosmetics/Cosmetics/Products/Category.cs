namespace Cosmetics.Products
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Common;
    using Contracts;

    public class Category : ICategory
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 15;

        private string name;
        private ICollection<IProduct> products;

        public Category(string name)
        {
            this.Name = name;

            this.products = new LinkedList<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                CustomValidator.StrInRangeAndNotNullOrEmpty(value, Category.MinNameLength, Category.MaxNameLength, "Category name");

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);

            var sortedProducts = this.products.OrderBy(p => p.Brand)
                                              .ThenByDescending(p => p.Price);

            this.products = new LinkedList<IProduct>(sortedProducts);
        }
        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (this.products.Contains(cosmetics))
            {
                this.products.Remove(cosmetics);
            }
            else
            {
                throw new ArgumentException(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
        }

        public string Print()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("{0} category - {1} {2} in total",
                                        this.Name, this.products.Count, this.products.Count == 1 ? "product" : "products"));

            foreach (var product in this.products)
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().TrimEnd();
        }
    }
}