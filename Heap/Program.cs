Heap heap = new();
heap.Insert(25);
heap.Insert(14);
heap.Insert(2);
heap.Insert(20);
heap.Insert(10);
var x = heap.HeapSort();
foreach (var val in x)
{
    Console.Write(val + " ");
}

public class Heap
{
    private const int MAX = 10000;
    private int[] Data { get; set; }
    private int Size { get; set; }

    public Heap()
    {
        Data = new int[MAX];
        Size = 0;
        Array.Fill(Data, -1);
    }

    public bool IsEmpty() => Size == 0;
    public bool IsFull() => Size == MAX;

    public void Insert(int value)
    {
        if (IsFull()) return;
        Size++;
        int heapIndex = Size;

        while (heapIndex > 1 && value > Data[heapIndex / 2])
        {
            Data[heapIndex] = Data[heapIndex / 2];
            heapIndex = heapIndex / 2;
        }
        Data[heapIndex] = value;
    }

    public int? Delete()
    {
        if (IsEmpty()) return null;
        int e = Data[1];
        Data[1] = Data[Size];
        Data[Size] = -1;
        --Size;
        int i = 1;
        int j = i * 2;

        while (j <= Size)
        {
            if (Data[j] < Data[j + 1]) j++;
            if (Data[i] < Data[j])
            {
                int temp = Data[i];
                Data[i] = Data[j];
                Data[j] = temp;
                i = j;
                j = i * 2;
            }
        }
        return e;
    }

    public int? Max()
    {
        if (IsEmpty()) return null;
        return Data[1];
    }

    public void Display()
    {
        for (int i = 1; i <= Size; ++i)  Console.Write(Data[i] + " ");
        Console.WriteLine();
    }

    public IEnumerable<int?> HeapSort()
    {
        int initSize = Size;
        for (int i = 1; i <= initSize; ++i) yield return this.Delete();
    }
}