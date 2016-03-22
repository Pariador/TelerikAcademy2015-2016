namespace Decorator
{
    public class CookieDecorator : ICookie
    {
        public CookieDecorator(ICookie cookie)
        {
            this.Cookie = cookie;
        }

        private ICookie Cookie { get; set; }

        public int Doe
        {
            get 
            {
                return this.Cookie.Doe;
            }
        }

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

        public virtual int GetTasteRating()
        {
            return this.Cookie.GetTasteRating();
        }
    }
}