namespace Size
{
    using System;

    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public Size GetRotatedSize(double angle)
        {
            double absoluteAngleCos = Math.Abs(Math.Cos(angle));
            double absoluteAngleSin = Math.Abs(Math.Sin(angle));

            Size result = new Size(0, 0);
            result.Width = (absoluteAngleCos * this.Width) + (absoluteAngleSin * this.Height);
            result.Height = (absoluteAngleSin * this.Width) + (absoluteAngleCos * this.Height);

            return result;
        }

        public override string ToString()
        {
            return string.Format("Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}