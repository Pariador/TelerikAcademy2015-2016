namespace Cosmetics.Products
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Common;
    using Contracts;

    public class Toothpaste : Product, IToothpaste, IProduct
    {
        private const int IngredientMinLength = 4;
        private const int IngredientMaxLength = 12;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name , brand, price, gender)
        {
            this.Ingredients = Toothpaste.GetIngredients(ingredients);
        }

        public string Ingredients
        {
            get;
            private set;
        }

        private static string GetIngredients(IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                CustomValidator.StrInRangeAndNotNullOrEmpty(ingredient, Toothpaste.IngredientMinLength, Toothpaste.IngredientMaxLength, "Ingredients");
            }

            return string.Join(", ", ingredients);
        }

        public override string Print()
        {
            var result = new StringBuilder();

            result.AppendLine(base.Print());
            result.Append(string.Format("  * Ingredients: {0}", this.Ingredients));

            return result.ToString();
        }
    }
}