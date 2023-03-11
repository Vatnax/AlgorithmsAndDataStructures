Console.WriteLine("RECURSIVE");
Console.WriteLine(Recursive(5));
Console.WriteLine("ITERATIVE");
Console.WriteLine(Iterative(5));

int Recursive(int n)
{
    if (n == 0) return 1;
    return Recursive(n - 1) * n;
}

int Iterative(int n)
{
    int factorial = 1;
    for (int i = 1; i <= n; ++i)
        factorial *= i;
    return factorial;
}