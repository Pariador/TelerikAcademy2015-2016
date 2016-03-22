namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> products;

        public ShoppingCart()
        {
            this.products = new LinkedList<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }
        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }
        public bool ContainsProduct(IProduct product)
        {
            return this.products.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal result = 0.00M;

            foreach (var product in this.products)
            {
                result += product.Price;
            }

            return result;
        }
    }
}