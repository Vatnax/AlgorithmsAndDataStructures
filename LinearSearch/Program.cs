int[] arr = { 3, 5, 4, 1, 2, 7 };
Console.WriteLine(LinearSearch(arr, 7));


int LinearSearch(int[] arr, int key)
{
    for (int i = 0; i < arr.Length; ++i)
        if (key == arr[i])
            return i;
    return -1;
}