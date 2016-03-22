using System;
using PhoneClassLibrary;

static class GSMCallHistoryTest
{
    public static void Test()
    {
        const decimal perMinuteCost = 0.37M;

        var myPhone = new GSM("1100", "Nokia");

        myPhone.CallHistory.Add(new Call("12345", DateTime.Now, new TimeSpan(0, 5, 0)));
        myPhone.CallHistory.Add(new Call("67891", DateTime.Now, new TimeSpan(0, 3, 14)));
        myPhone.CallHistory.Add(new Call("01112", DateTime.Now, new TimeSpan(0, 0, 55)));
        myPhone.CallHistory.Add(new Call("13141", DateTime.Now, new TimeSpan(0, 28, 13)));
        myPhone.CallHistory.Add(new Call("51617", DateTime.Now, new TimeSpan(0, 7, 51)));

        foreach (var call in myPhone.CallHistory)
        {
            Console.WriteLine(call);
        }
        Console.WriteLine("Total Calls Cost: {0}\n", myPhone.TotalCallsCost(perMinuteCost));

        var longestCall = myPhone.CallHistory[0];
        for (int i = 1; i < myPhone.CallHistory.Count; i++)
        {
            if (longestCall.CallDuration < myPhone.CallHistory[i].CallDuration)
            {
                longestCall = myPhone.CallHistory[i];
            }
        }
        myPhone.CallHistory.Remove(longestCall);

        foreach (var call in myPhone.CallHistory)
        {
            Console.WriteLine("{0}", call);
        }
        Console.WriteLine("Total Calls Cost: {0}", myPhone.TotalCallsCost(perMinuteCost));
    }
}