using System;
using PhoneClassLibrary;
using System.Collections.Generic;

static class GSMTest
{
    public static void Test()
    {
        List<GSM> gsmList = new List<GSM>();

        gsmList.Add(new GSM("Galaxy Note 4", "Samsung"));
        gsmList.Add(new GSM("6070", "Nokia", 9.99, new Display(1.8, 65000), new Battery(BatteryType.LiIon, new TimeSpan(300, 0, 0), new TimeSpan(3, 0, 0), "760")));
        gsmList.Add(new GSM("IPhone 6 Plus", "Apple", 399.99, new Display(5.5, 16000000),
            new Battery(BatteryType.LiPoly, new TimeSpan(384, 0, 0), new TimeSpan(24, 0, 0), "2915"), "Steve"));

        foreach (var gsm in gsmList)
        {
            Console.WriteLine("{0}\n", gsm.ToString());
        }

        Console.WriteLine("{0}\n", GSM.IPhone4S.ToString());
    }
}
