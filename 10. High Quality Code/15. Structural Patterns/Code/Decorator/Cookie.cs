namespace Decorator
{
    public class Cookie : ICookie
    {
        public Cookie()
        {
            this.Doe = 1;
        }

        public int Doe {get; private set;}

        public ICookie ICookie
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int GetTasteRating()
        {
            return this.Doe;
        }
    }
}