# Data Structures, Algorithms and Complexity Homework
## 01. What is the expected running time of the following C# code?
```C#
long Compute(int[] arr)
{
    long count = 0;
    for (int i=0; i<arr.Length; i++)
    {
        int start = 0, end = arr.Length-1;
        while (start < end)
            if (arr[start] < arr[end])
                { start++; count++; }
            else
                end--;
    }
    return count;
}
```

### Answer:
**n * (n - 1)** => The `for` loop will loop **n** times, the `while` loop will loop **n - 1** times because `end = arr.Length-1;`.

## 02. What is the expected running time of the following C# code?
```C#
long CalcCount(int[,] matrix)
{
    long count = 0;
    for (int row=0; row<matrix.GetLength(0); row++)
        if (matrix[row, 0] % 2 == 0)
            for (int col=0; col<matrix.GetLength(1); col++)
                if (matrix[row,col] > 0)
                    count++;
    return count;
}
```

### Answer:
**n * (m / 2)** => We loop through all rows **(n)**, but we only loop through the columns 50% of the time **(m / 2)**, assuming any int can be in the matrix.

## 03. (*) What is the expected running time of the following C# code?
```C#
long CalcSum(int[,] matrix, int row)
{
    long sum = 0;
    //HW COMMENT: GetLength(0), should be GetLength(1), to loop through the columns.
    for (int col = 0; col < matrix.GetLength(0); col++)
        sum += matrix[row, col];
    //HW COMMENT: GetLength(1), should be GetLength(0), to check the row.
    if (row + 1 < matrix.GetLength(1))
        sum += CalcSum(matrix, row + 1);
    return sum;
}

Console.WriteLine(CalcSum(matrix, 0));
```

### Answer:
**n \* n** => The code will add up every element of the matrix but will work correctly only if (n == m) => **(n * n)**, check the comments in the code for why that is.