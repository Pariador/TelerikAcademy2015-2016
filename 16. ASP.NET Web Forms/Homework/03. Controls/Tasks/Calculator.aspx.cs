namespace Tasks
{
	using System;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Collections.Generic;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class Calculator : Page
	{
		private const string Plus = "+";

		private const string Minus = "-";

		private const string Times = "*";

		private const string Devide = "/";

		private const string Sqrt = "√";

		private static readonly string[] Operators =
		{
			Calculator.Plus,
			Calculator.Minus,
			Calculator.Times,
			Calculator.Devide,
			Calculator.Sqrt,
		};

		protected void Page_Init(object sender, EventArgs args)
		{
			this.ButtonPlus.Text = Calculator.Plus;
			this.ButtonMinus.Text = Calculator.Minus;
			this.ButtonTimes.Text = Calculator.Times;
			this.ButtonDevide.Text = Calculator.Devide;
			this.ButtonSqrt.Text = Calculator.Sqrt;
		}

		protected void EnterSymbol(object sender, EventArgs args)
		{
			Button button = (Button)sender;

			this.Screen.Text += button.Text;
		}

		protected void Calculate(object sender, EventArgs args)
		{
			string operators = Calculator.Operators.Select(oprtr => "\\" + oprtr)
				.Join("");

			var expressionEnum = Regex.Split(this.Screen.Text, $@"(?<=[{operators}])|(?=[{operators}])")
				.Select(str => str.Trim());

			var expression = new LinkedList<string>(expressionEnum);

			bool removed;
			do
			{
				removed = expression.Remove(string.Empty);
			} while (removed);

			try
			{
				this.CalculateSqrt(expression);
				this.CalculateMultiplicationAndDivision(expression);
				this.CalculateAdditionAndSubtraction(expression);

				this.Screen.Text = expression.Join("");
			}
			catch (CalculationException)
			{
				this.Screen.Text = "Error!";
			}
		}

		protected void Clear(object sender, EventArgs args)
		{
			this.Screen.Text = string.Empty;
		}

		private LinkedList<string> CalculateSqrt(LinkedList<string> expression)
		{
			while (true)
			{
				var sqrt = expression.Find(Calculator.Sqrt);

				if (sqrt == null)
				{
					return expression;
				}

				if (sqrt.Next == null)
				{
					throw new CalculationException("No sqrt argument.");
				}

				int number = int.Parse(sqrt.Next.Value);

				int numberSqrt = (int)Math.Sqrt(number);

				expression.Remove(sqrt.Next);

				sqrt.Value = numberSqrt.ToString();
			}
		}

		private LinkedList<string> CalculateMultiplicationAndDivision(LinkedList<string> expression)
		{
			while (true)
			{
				var validNode = expression.Find(node => node.Value == Calculator.Times || node.Value == Calculator.Devide);

				if (validNode == null)
				{
					return expression;
				}

				if (validNode.Previous == null || validNode.Next == null)
				{
					throw new CalculationException("Multiplication and division need 2 arguments.");
				}

				int left = int.Parse(validNode.Previous.Value);
				int right = int.Parse(validNode.Next.Value);

				expression.Remove(validNode.Previous);
				expression.Remove(validNode.Next);

				validNode.Value = validNode.Value == Calculator.Times ? (left * right).ToString() : (left / right).ToString();
			}
		}

		private LinkedList<string> CalculateAdditionAndSubtraction(LinkedList<string> expression)
		{
			while (true)
			{
				var validNode = expression.Find(node => node.Value == Calculator.Plus || node.Value == Calculator.Minus);

				if (validNode == null)
				{
					return expression;
				}

				if (validNode.Previous == null || validNode.Next == null)
				{
					throw new CalculationException("Addition and subtraction need 2 arguments.");
				}

				int left = int.Parse(validNode.Previous.Value);
				int right = int.Parse(validNode.Next.Value);

				expression.Remove(validNode.Previous);
				expression.Remove(validNode.Next);

				validNode.Value = validNode.Value == Calculator.Plus ? (left + right).ToString() : (left - right).ToString();
			}
		}
	}
}