Console.WriteLine("RECURSIVE");
Console.WriteLine(Recursive(5));
Console.WriteLine("CONSTANT");
Console.WriteLine(Constant(5));
Console.WriteLine("ITERATIVE");
Console.WriteLine(Iterative(5));

int Recursive(int n)
{
    if (n == 1) return 1;
    return Recursive(n - 1) + n;
}

int Constant(int n)
{
    return (n * n + n) / 2;
}

int Iterative(int n)
{
    int sum = 0;
    for (int i = 1; i <= n; ++i)
        sum += i;
    return sum;
}