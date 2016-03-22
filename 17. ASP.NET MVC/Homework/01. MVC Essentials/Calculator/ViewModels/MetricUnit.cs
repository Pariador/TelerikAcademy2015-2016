namespace Calculator.ViewModels
{
	public class MetricUnit
	{
		private MetricPrefix prefix;
		
		private Unit unit;

		public MetricUnit(MetricPrefix prefix, KiloValue kiloValue, Unit unit, decimal value, bool isValueInBits)
		{
			this.Prefix = prefix;
			this.KiloValue = kiloValue;
			this.Unit = unit;

			if (isValueInBits)
			{
				this.SetValueFromBits(value);
			}
			else
			{
				this.Value = value;
			}
		}

		public MetricUnit()
			: this(MetricPrefix.None, KiloValue.Kibi, Unit.Byte, value: 0, isValueInBits: false)
		{
			;
		}

		public MetricPrefix Prefix
		{
			get
			{
				return this.prefix;
			}

			set
			{
				this.prefix = value;

				this.UpateBitsPerValue();
			}
		}

		public KiloValue KiloValue { get; set; }

		public decimal BitsPerValue { get; private set; }

		public Unit Unit
		{
			get
			{
				return this.unit;
			}

			set
			{
				this.unit = value;

				this.UpateBitsPerValue();
			}
		}

		public decimal Value { get; set; }

		public string FullName
		{
			get
			{
				if (this.Prefix == MetricPrefix.None)
				{
					return this.Unit.ToString();
				}

				return this.Prefix + this.Unit.ToString().ToLower();
			}
		}

		public MetricUnit SetValueFromBits(decimal bits)
		{
			this.Value = bits / this.BitsPerValue;
			
			return this;
		}

		public decimal ToBits()
		{
			return this.BitsPerValue * this.Value;
		}

		private MetricUnit UpateBitsPerValue()
		{
			this.BitsPerValue = ((decimal)this.KiloValue).Pow((int)this.Prefix) * (int)this.Unit;

			return this;
		}
	}
}