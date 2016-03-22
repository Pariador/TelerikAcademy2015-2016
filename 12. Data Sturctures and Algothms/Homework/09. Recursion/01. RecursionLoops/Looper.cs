namespace RecursionLoops
{
	using System;

	public static class Looper
	{
		public static void ForLoops(ref int from, ref int to, int count, Action action)
		{
			if (count == 0)
			{
				return;
			}

			for (int i = from; i < to; i++)
			{
				if (count == 1)
				{
					action();
				}

				Looper.ForLoops(ref from, ref to, count - 1, action);
			}
		}
	}
}