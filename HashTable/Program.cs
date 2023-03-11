
HashTable h = new();
h.Insert(10);
h.Insert(20);
h.Insert(30);
h.Insert(31);
h.Display();
Console.WriteLine(h.Search(11));

public class HashTable
{
    public int ComputeHashCode<T>(T element)
    {
        return Math.Abs(element.GetHashCode() % sizeOfHashTable);
    }

    private LinkedList[] Data { get; init; }
    private const int MAX = 10;

    public HashTable()
    {
        Data = new LinkedList[MAX];
        for (int i = 0; i < Data.Length; ++i)
            Data[i] = new();
    }

    public int HashCode(int key)
    {
        return key % MAX;
    }

    public void Insert(int key)
    {
        int i = HashCode(key);
        Data[i].InsertSorted(key);
    }

    public bool Search(int e)
    {
        int i = HashCode(e);
        return Data[i].Find(e) != -1;
    }

    public void Display()
    {
        for (int i = 0; i < Data.Length; ++i)
        {
            Console.Write("[" + i + "]");
            Data[i].Display();
        }
        Console.WriteLine();
    }
}