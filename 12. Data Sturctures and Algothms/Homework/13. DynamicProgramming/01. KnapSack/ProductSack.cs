namespace KnapSack
{
	using System;

	public class ProductSack : IComparable<ProductSack>
	{
		public readonly int MaxWeight;

		public ProductSack(int maxWeight)
		{
			this.MaxWeight = maxWeight;

			this.CurrentWeight = 0;
			this.CurrentCost = 0;
		}

		public int CurrentWeight { get; private set; }

		public int CurrentCost { get; private set; }

		public bool CanAddProduct(Product product)
		{
			return (this.CurrentWeight + product.Weight) <= this.MaxWeight;
		}

		public ProductSack AddProduct(Product product)
		{
			if (!this.CanAddProduct(product))
			{
				throw new ArgumentException("Can't add product.");
			}

			this.CurrentWeight += product.Weight;
			this.CurrentCost += product.Cost;

			return this;
		}

		public bool Equals(ProductSack other)
		{
			if (other == null)
			{
				return false;
			}

			return this.CurrentWeight == other.CurrentWeight && this.CurrentCost == other.CurrentCost;
		}

		public override bool Equals(object obj)
		{
			ProductSack other = obj as ProductSack;
			if (other == null)
			{
				return false;
			}

			return this.Equals(other);
		}

		public override int GetHashCode()
		{
			return this.CurrentCost ^ this.CurrentWeight;
		}

		public int CompareTo(ProductSack other)
		{
			return this.CurrentCost.CompareTo(other.CurrentCost);
		}

		public ProductSack Clone()
		{
			return (ProductSack)this.MemberwiseClone();
		}

		public override string ToString()
		{
			return $"Weight => {this.CurrentWeight} : Cost => {this.CurrentCost}";
		}
	}
}