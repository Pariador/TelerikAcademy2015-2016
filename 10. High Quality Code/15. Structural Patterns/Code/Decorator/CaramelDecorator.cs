namespace Decorator
{
    public class CaramelDecorator : CookieDecorator
    {
        public CaramelDecorator(ICookie cookie)
            : base(cookie)
        {
            this.Caramel = 4;
        }

        public int Caramel { get; private set; }

        public override int GetTasteRating()
        {
            return base.GetTasteRating() + this.Caramel;
        }
    }
}