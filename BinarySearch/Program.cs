int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
Console.WriteLine("ITERATIVE");
Console.WriteLine(Iterative(arr, 7));
Console.WriteLine("RECURSIVE");
Console.WriteLine(Recursive(arr, 8, 0, arr.Length - 1));


int Iterative(int[] arr, int key)
{
    int l = 0;
    int r = arr.Length - 1;

    while (l <= r)
    {
        int m = (l + r) / 2;
        if (key == arr[m])
            return m;
        if (key < arr[m])
            r = m - 1;
        else if (key > arr[m])
            l = m + 1;
    }

    return -1;
}

int Recursive(int[] arr, int key, int l, int r)
{
    if (l > r)
        return -1;

    int m = (l + r) / 2;
    if (key == arr[m])
        return m;
    if (key < arr[m])
        return Recursive(arr, key, l, m - 1);
    if (key > arr[m])
        return Recursive(arr, key, m + 1, r);

    return -1;
}