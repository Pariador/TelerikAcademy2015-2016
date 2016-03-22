bool found = false;
for (int i = 0; i < 100; i++)
{
	Console.WriteLine(i);
	if (i % 10 != 0)
	{
		continue;
	}

	if (array[i] == expectedValue)
	{
		found = true;
	}
}

// More code here.

if (found)
{
	Console.WriteLine("Value Found.");
}