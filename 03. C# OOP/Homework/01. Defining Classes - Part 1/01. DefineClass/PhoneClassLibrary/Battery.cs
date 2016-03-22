namespace PhoneClassLibrary
{
    using System;
    using System.Text;

    public enum BatteryType
    {
        LiPoly, LiIon, NiCd, NiMH
    }

    class Battery
    {
        private const string unknownModel = "[Unknown Model]";
        private const string unknownTime = "[Unknown Time]";

        private string model;
        private BatteryType type;
        private TimeSpan? idleTime;
        private TimeSpan? callTime;

        public Battery(BatteryType type)
        {
            this.Type = type;
            this.idleTime = null;
            this.callTime = null;
            this.model = null;
        }
        public Battery(BatteryType type, TimeSpan idleTime, TimeSpan callTime) : this(type)
        {
            this.IdleTime = idleTime;
            this.CallTime = callTime;
        }
        public Battery(BatteryType type, TimeSpan idleTime, TimeSpan callTime, string model) : this(type, idleTime, callTime)
        {
            this.Model = model;
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
        public BatteryType Type
        {
            get
            {
                return type;
            }
            set
            {
                this.type = value;
            }
        }
        public TimeSpan? IdleTime
        {
            get
            {
                return this.idleTime;
            }
            set
            {
                this.idleTime = value;
            }
        }
        public TimeSpan? CallTime
        {
            get
            {
                return this.callTime;
            }
            set
            {
                this.callTime = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            const string placeHoler = "{0}: {1}, ";
            const string lastHodler = "{0}: {1}";
            const string type = "Type";
            const string idleTime = "IdleTime";
            const string callTime = "CallTime";
            const string model = "Model";

            result.Append(String.Format(placeHoler, type, this.Type));
            if (this.IdleTime != null)
            {
                result.Append(String.Format(placeHoler, idleTime, this.IdleTime));  
            }
            else
            {
                result.Append(String.Format(placeHoler, idleTime, unknownTime));  
            }

            if (this.CallTime != null)
            {
                result.Append(String.Format(placeHoler, callTime, this.CallTime));
            }
            else
            {
                result.Append(String.Format(placeHoler, callTime, unknownTime));
            }
            result.Append(String.Format(lastHodler, model, this.Model));

            return result.ToString();
        }
    }
}