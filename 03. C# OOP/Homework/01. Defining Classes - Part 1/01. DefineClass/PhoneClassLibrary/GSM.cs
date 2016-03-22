namespace PhoneClassLibrary
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    class GSM
    {
        private static readonly GSM iPhone4S = 
            new GSM("IPhone4S", "Apple", 262.99, new Display(3.5, 16000000), new Battery(BatteryType.LiPoly,  new TimeSpan(200,0,0), new TimeSpan(14,0,0), "1432"));

        private const string unknownModel = "[Unknown Model]";
        private const string unknownManufac = "[Unknown Manufacturer]";
        private const string unknownOwner = "[Unknown Owner]";
        private const string unknownPrice = "[Unknown Price]";
        private const string unknownBattery = "[Unknown Battery]";
        private const string unknownDisplay = "[Unknown Display]";

        private double? price;
        private string model;
        private string manufacturer;
        private string owner;
        private Battery batteryGSM;
        private Display displayGSM;
        private List<Call> callHistory;

        private GSM()
        {   
            this.price = null;
            this.model = unknownModel;
            this.manufacturer = unknownManufac;           
            this.owner = unknownOwner;
            this.batteryGSM = null;
            this.displayGSM = null;
            this.callHistory = new List<Call>();
        }
        public GSM(string model, string manufacturer) : this()
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }
        public GSM(string model, string manufacturer, double price, Display display, Battery battery) : this(model, manufacturer)
        {
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.GSMDisplay = display;
            this.GSMBattery = battery;
        }
        public GSM(string model, string manufacturer, double price, Display display, Battery battery, string owner) : this(model, manufacturer, price, display, battery)
        {
            this.Owner = owner;
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                value = value.Trim();
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model can not be empty, null or whitespace.");
                }
                this.model = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                value = value.Trim();
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manufacturer can not be empty, null or whitespace.");
                }
                this.manufacturer = value;
            }
        }
        public double? Price
        {
            get
            { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can not be equal to or less than zero.");
                }

                this.price = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                value = value.Trim();
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Owner can not be empty, null or whitespace.");
                }
                this.owner = value;
            }
        }
        public Battery GSMBattery
        {
            get
            {
                return this.batteryGSM;
            }
            set
            {
                this.batteryGSM = value;
            }
        }
        public Display GSMDisplay
        {
            get
            {
                return this.displayGSM;
            }
            set
            {
                this.displayGSM = value;
            }
        }
        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                this.callHistory = value;
            }
        }

        public decimal TotalCallsCost(decimal costPerMinute)
        {
            var totalCallTime = new TimeSpan();

            foreach (var call in this.CallHistory)
            {
                if (call.CallDuration != null)
                {
                    totalCallTime += (TimeSpan)call.CallDuration;
                }
            }

            return totalCallTime.Minutes * costPerMinute;
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            const string placeHolder = "{0}: {1}, ";
            const string classHolder = "{0}: ({1}), ";
            const string model = "Model";
            const string manufacturer = "Manufacturer";
            const string price = "Price";
            const string owner = "Owner";
            const string battery = "BatteryInfo";
            const string display = "DisplayInfo";

            result.Append(String.Format(placeHolder, model, this.Model));
            result.Append(String.Format(placeHolder, manufacturer, this.Manufacturer));
            if (this.Price != null)
            {
                result.Append(String.Format(placeHolder, price, this.Price));
            }
            else
            {
                result.Append(String.Format(placeHolder, price, unknownPrice));
            }
            if (this.GSMBattery != null)
            {
                result.Append(String.Format(classHolder, battery, this.GSMBattery.ToString()));
            }
            else
            {
                result.Append(String.Format(classHolder, battery, unknownBattery));
            }

            if (this.GSMDisplay != null)
            {
                result.Append(String.Format(classHolder, display, this.GSMDisplay.ToString()));
            }
            else
            {
                result.Append(String.Format(classHolder, display, unknownDisplay));
            }
            result.Append(String.Format("{0}: {1}", owner, this.Owner));

            return result.ToString();
        }
    }
}