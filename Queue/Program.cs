
public class QueueUsingArray
{
    private const int MAX = 100000;
    public int[] Storage { get; set; } = new int[MAX];
    public int Size { get; private set; }
    private int Front { get; set; }
    private int Rear { get; set; }

    public void Enqueue(int value)
    {
        if (IsFull()) return;
        Storage[Rear] = value;
        Rear++;
        Size++;
    }

    public int? Dequeue()
    {
        if (IsEmpty()) return null;
        int ret = Storage[Front];
        Front++;
        Size--;
        return ret;
    }

    public void Display()
    {
        for(int i = Front; i < Rear; ++i)
        {
            Console.Write(Storage[i] + " ");
        }
        Console.WriteLine();
    }

    public int? Peek() => IsEmpty() ? null : Storage[Front];

    public bool IsFull() => Size == MAX;
    public bool IsEmpty() => Size == 0;
}

public class QueueUsingLinkedList
{
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

    public int Size { get; private set; }
    public Node Front { get; set; }
    public Node Rear { get; set; }

    public void Enqueue(int value)
    {
        Node newest = new Node(value, null);
        if (IsEmpty())
        {
            Front = newest;
        }
        else
        {
            Rear.Next = newest;
        }
        Rear = newest;
        ++Size;
    }

    public int? Dequeue()
    {
        if (IsEmpty()) return null;
        var ret = Front.Value;
        Front = Front.Next;
        --Size;
        return ret;
    }

    public void Display()
    {
        Node current = Front;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public int? Peek() => IsEmpty() ? null : Front.Value;
    public bool IsEmpty() => Size == 0;
}

