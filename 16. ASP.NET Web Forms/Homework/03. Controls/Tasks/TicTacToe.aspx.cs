using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tasks
{
	public partial class TicTacToe : System.Web.UI.Page
	{
		private const string EmptySymbol = "#";

		private const string PlayerSymbol = "O";

		private const string EnemySymbol = "X";

		private const string PlayerVictoryMessage = "You win!";

		private const string EnemyVictoryMessage = "You loose!";

		private const string StaleMateMessage = "StaleMate!";

		protected void Page_Init(object sender, EventArgs args)
		{
			this.Start(sender, args);
		}

		protected void Start(object sender, EventArgs args)
		{
			this.GameResult.Text = "";

			Button[,] board = this.ReadBoard();

			for (int row = 0; row < board.GetLength(0); row++)
			{
				for (int col = 0; col < board.GetLength(1); col++)
				{
					board[row, col].Text = TicTacToe.EmptySymbol;
				}
			}
		}

		protected void ExecuteTurn(object sender, EventArgs args)
		{
			Button clicked = (Button)sender;

			if (this.GameResult.Text != string.Empty || clicked.Text == TicTacToe.PlayerSymbol || clicked.Text == TicTacToe.EnemySymbol)
			{
				return;
			}

			Button[,] board = this.ReadBoard();

			clicked.Text = TicTacToe.PlayerSymbol;

			if (this.IsGameOver(board))
			{
				return;
			}

			this.EnemyTurn(board);

			if (this.IsGameOver(board))
			{
				return;
			}
		}

		private Button[,] ReadBoard()
		{
			Panel[] rows = this.Board.Controls.Cast<object>()
				.Select(ctrl => ctrl as Panel)
				.Where(panel => panel != null)
				.ToArray();

			Button[,] board = new Button[3, 3];

			for (int row = 0; row < rows.Length; row++)
			{
				Button[] cols = rows[row].Controls.Cast<object>()
					.Select(ctrl => ctrl as Button)
					.Where(button => button != null)
					.ToArray();

				for (int col = 0; col < cols.Length; col++)
				{
					board[row, col] = cols[col];
				}
			}

			return board;
		}

		private bool IsGameOver(Button[,] board)
		{
			string rowVictory = this.HasRowVictory(board);
			if (rowVictory == TicTacToe.PlayerSymbol)
			{
				this.GameResult.Text = TicTacToe.PlayerVictoryMessage;
				return true;
			}

			if (rowVictory == TicTacToe.EnemySymbol)
			{
				this.GameResult.Text = TicTacToe.EnemyVictoryMessage;
				return true;
			}

			string colVictory = this.HasColVictory(board);
			if (colVictory == TicTacToe.PlayerSymbol)
			{
				this.GameResult.Text = TicTacToe.PlayerVictoryMessage;
				return true;
			}

			if (colVictory == TicTacToe.EnemySymbol)
			{
				this.GameResult.Text = TicTacToe.EnemyVictoryMessage;
				return true;
			}

			string daigVictory = this.HasDiagVictory(board);
			if (daigVictory == TicTacToe.PlayerSymbol)
			{
				this.GameResult.Text = TicTacToe.PlayerVictoryMessage;
				return true;
			}

			if (daigVictory == TicTacToe.EnemySymbol)
			{
				this.GameResult.Text = TicTacToe.EnemyVictoryMessage;
				return true;
			}

			if (this.IsStaleMate(board))
			{
				this.GameResult.Text = TicTacToe.StaleMateMessage;
				return true;
			}

			return false;
		}

		private string HasRowVictory(Button[,] board)
		{
			for (int row = 0; row < board.GetLength(0); row++)
			{
				int sameSymbolsCount = 0;

				int cols = board.GetLength(1);
				for (int col = 1; col < cols; col++)
				{
					if (board[row, col - 1].Text == board[row, col].Text)
					{
						sameSymbolsCount++;
					}
				}

				if (sameSymbolsCount == cols - 1)
				{
					return board[row, 0].Text;
				}
			}

			return "";
		}

		private string HasColVictory(Button[,] board)
		{
			for (int col = 0; col < board.GetLength(1); col++)
			{
				int sameSymbolsCount = 0;

				int rows = board.GetLength(0);
				for (int row = 1; row < rows; row++)
				{
					if (board[row - 1, col].Text == board[row, col].Text)
					{
						sameSymbolsCount++;
					}
				}

				if (sameSymbolsCount == rows - 1)
				{
					return board[0, col].Text;
				}
			}

			return "";
		}

		private string HasDiagVictory(Button[,] board)
		{
			int leftDiagSymbolsCount = 0;
			int rightDiagSymbolsCount = 0;
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			for (int i = 1; i < rows; i++)
			{
				int rightDiagCol = (cols - 1) - i;

				if (board[i - 1, i - 1].Text == board[i, i].Text)
				{
					leftDiagSymbolsCount++;
				}

				if (board[i - 1, rightDiagCol + 1].Text == board[i, rightDiagCol].Text)
				{
					rightDiagSymbolsCount++;
				}
			}

			if (leftDiagSymbolsCount == rows - 1)
			{
				return board[0, 0].Text;
			}

			if (rightDiagSymbolsCount == rows - 1)
			{
				return board[0, cols - 1].Text;
			}

			return "";
		}

		private bool IsStaleMate(Button[,] board)
		{
			return board.Cast<Button>()
				.All(button => button.Text != TicTacToe.EmptySymbol);
		}

		private void EnemyTurn(Button[,] board)
		{
			var emptyCells = board.Cast<Button>()
				.Where(button => button.Text == TicTacToe.EmptySymbol)
				.ToArray();

			var index = Randomizer.Random.Next(0, emptyCells.Length);

			emptyCells[index].Text = TicTacToe.EnemySymbol;
		}
	}
}