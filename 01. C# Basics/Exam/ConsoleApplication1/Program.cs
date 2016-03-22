using System;

class Program
{
    static void Main()
    {
        int[] nums = new int[3];
        nums[0] = int.Parse(Console.ReadLine());
        nums[1] = int.Parse(Console.ReadLine());
        nums[2] = int.Parse(Console.ReadLine());

        int biggest = nums[0];
        int smallest = nums[0];

        if (biggest < nums[1])
        {
            biggest = nums[1];
        }

        if (biggest < nums[2])
        {
            biggest = nums[2];
        }

        if (smallest > nums[1])
        {
            smallest = nums[1];
        }

        if (smallest > nums[2])
        {
            smallest = nums[2];
        }

        Console.WriteLine(biggest);
        Console.WriteLine(smallest);
        Console.WriteLine("{0:F2}", (nums[0] + nums[1] + nums[2])/3.0);
    }
}