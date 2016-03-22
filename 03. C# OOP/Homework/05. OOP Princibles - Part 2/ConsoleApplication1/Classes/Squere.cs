namespace Shapes
{
    using System;

    public class Squere : Rectangle
    {
        public Squere(double side) : base(side, side)
        {
            ;
        }

        public override double Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
        public override double Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}