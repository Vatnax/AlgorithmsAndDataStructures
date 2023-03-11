Console.WriteLine("ITERATIVE");
Console.WriteLine(Iterative(4, 10));
Console.WriteLine("RECURSIVE");
Console.WriteLine(Recursive(4, 10));

int Iterative(int _base, int exp)
{
    if (_base == 0) return 1;

    int x = 1;
    for (int i = 0; i < exp; ++i)
    {
        x *= _base;
    }
    return x;
}

int Recursive(int _base, int exp)
{
    if (_base == 0) return 1;
    if (exp == 1) return _base;
    return Recursive(_base, exp - 1) * _base;
}