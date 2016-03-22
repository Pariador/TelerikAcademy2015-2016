namespace Facade
{
    public static class Program
    {
        public static Circle Circle
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public static void Main()
        {
            Circle circle = new Circle(50, 50, 15);
            circle.Draw();
        }
    }
}