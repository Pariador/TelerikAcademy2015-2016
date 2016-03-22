namespace ZigZagSequenceSolution
{
	using System;

	public class ZigZagSequence
	{
		public static int[] CurrentSequence;

		public static int SetLength;
		public static bool[] Used;

		public static int Count;

		public static void Main()
		{
			string[] input = Console.ReadLine()
				.Split(' ');

			int setLength = int.Parse(input[0]);
			int sequenceLength = int.Parse(input[1]);

			var counter = new ZigZagSequenceCounter(setLength, sequenceLength);

			Console.WriteLine(counter.Count());
		}
	}

	public class ZigZagSequenceCounter
	{
		public ZigZagSequenceCounter(int setLength, int sequenceLength)
		{
			this.SetLength = setLength;
			this.SequenceLength = sequenceLength;

			this.Used = new bool[this.SetLength];

			this.SequenceCounter = 0;
		}

		public int SetLength { get; set; }

		public int SequenceLength { get; set; }

		public bool[] Used { get; set; }

		private int SequenceCounter { get; set; }

		public int Count()
		{
			if (this.SequenceCounter != 0)
			{
				return this.SequenceCounter;
			}

			this.CountSequences(0, 0);

			return this.SequenceCounter;
		}

		private void CountSequences(int index, int previous)
		{
			if (index == this.SequenceLength)
			{
				this.SequenceCounter++;
				return;
			}

			int start = 0;
			int end = this.SetLength;

			if ((index % 2) == 0)
			{
				start = previous + 1;
			}
			else
			{
				end = previous;
			}

			for (int number = start; number < end; number++)
			{
				if (!this.Used[number])
				{
					this.Used[number] = true;

					this.CountSequences(index + 1, number);

					this.Used[number] = false;
				}
			}
		}
	}
}