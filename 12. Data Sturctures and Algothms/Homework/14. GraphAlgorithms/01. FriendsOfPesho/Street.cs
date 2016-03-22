namespace FriendsOfPesho
{
	public class Street
	{
		public Street(int to, int distance)
		{
			this.To = to;
			this.Distance = distance;
		}

		public int To { get; private set; }

		public int Distance { get; private set; }
	}
}