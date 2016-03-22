namespace PhoneClassLibrary
{
    using System;
    using System.Text;

    class Display
    {
        private const string unknownValue = "[Unknown]";

        private int? colorsCount;
        private double? screenSize;

        public Display(double screenSize)
        {
            this.ScreenSize = screenSize;
            this.colorsCount = null;
        }
        public Display(int colorsCount)
        {
            this.ColorsCount = colorsCount;
            this.screenSize = null;
        }
        public Display(double screenSize, int colorsCount)
        {
            this.ScreenSize = screenSize;
            this.ColorsCount = colorsCount;
        }

        public int? ColorsCount
        {
            get
            {
                return this.colorsCount;
            }
            set
            {
                if (value < 2)
                {
                    throw new ArgumentException("The number of colors can not be less than 2.");
                }

                this.colorsCount = value;
            }
        }
        public double? ScreenSize
        {
            get
            {
                return this.screenSize;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Screen size can't be equel to or less than zero.");
                }

                this.screenSize = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            const string firstHolder = "{0}: {1}, ";
            const string lastHolder = "{0}: {1}";
            const string screenSize = "ScreenSize";
            const string colors = "Colors";

            if (this.ScreenSize != null)
            {
                result.Append(String.Format(firstHolder, screenSize, this.ScreenSize));
            }
            else
            {
                result.Append(String.Format(firstHolder, screenSize, unknownValue));
            }

            if (this.colorsCount != null)
            {
                result.Append(String.Format(lastHolder, colors, this.ColorsCount));
            }
            else
            {
                result.Append(String.Format(lastHolder, colors, unknownValue));
            }


            return result.ToString();
        }
    }
}