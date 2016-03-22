namespace Decorator
{
    public class ChocolateDecorator : CookieDecorator
    {
        public ChocolateDecorator(ICookie cookie)
            : base(cookie)
        {
            this.Chocolate = 5;
        }

        public int Chocolate { get; private set; }

        public override int GetTasteRating()
        {
            return base.GetTasteRating() + this.Chocolate;
        }
    }
}