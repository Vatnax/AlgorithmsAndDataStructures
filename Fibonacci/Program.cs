Console.WriteLine("ITERATIVE");
Console.WriteLine(Iterative(10));
Console.WriteLine("RECURSIVE");
Console.WriteLine(Recursive(10));

int Iterative(int n)
{
    int prev = 1;
    int more_prev = 1;
    int temp = 0;
    for (int i = 2; i < n; ++i)
    {
        temp = prev;
        prev += more_prev;
        more_prev = temp;
    }

    return prev;
}

int Recursive(int n)
{
    if (n <= 2) return 1;
    return Recursive(n - 1) + Recursive(n - 2);
}