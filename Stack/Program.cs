

public class StackUsingArray
{
    private const int MAX = 100000;
    public int Size { get; private set; }
    private int[] Storage { get; set; } = new int[MAX];

    public bool IsEmpty() => Size == 0;
    public bool IsFull() => Size == MAX;

    public void Push(int value)
    {
        if (IsFull()) return;
        Storage[Size++] = value;
    }

    public void Pop()
    {
        if (IsEmpty()) return;
        --Size;
    }

    public int? Top() => IsEmpty() ? null : Storage[Size - 1];

    public void Display()
    {
        for (int i = 0; i < Size; ++i)
        {
            Console.Write(Storage[i] + " ");
        }
        Console.WriteLine();
    }
}

public class StackUsingLinkedList
{
    public int Size { get; private set; }
    private Node TopElement { get; set; }
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value, Node next)
        {
            Value = value;
            Next = next;
        }
    }

    public bool IsEmpty() => Size == 0;

    public void Push(int value)
    {
        Node newest = new Node(value, null);
        if (IsEmpty())
        {
            TopElement = newest;
        }
        else
        {
            newest.Next = TopElement;
            TopElement = newest;
        }
        ++Size;
    }

    public void Pop()
    {
        if (IsEmpty()) return;
        TopElement = TopElement.Next;
        --Size;
    }

    public int? Top() => IsEmpty() ? null : TopElement.Value;

    public void Display()
    {
        Node current = TopElement;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}