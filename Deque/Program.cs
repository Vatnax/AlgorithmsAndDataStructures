public class DequeUsingLinkedList
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
    private Node Head { get; set; }
    private Node Tail { get; set; }

    public bool IsEmpty() => Size == 0;

    public void AddLast(int value)
    {
        Node newest = new Node(value, null);
        if (IsEmpty())
            Head = newest;
        else
            Tail.Next = newest;
        Tail = newest;
        ++Size;
    }

    public void Display()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void AddFirst(int value)
    {
        Node newest = new Node(value, Head);
        if (IsEmpty())
            Tail = newest;
        Head = newest;
        ++Size;
    }

    public void DeleteFirst()
    {
        if (IsEmpty()) return;
        Head = Head.Next;
        --Size;
        if (IsEmpty()) Tail = null;
    }

    public void DeleteLast()
    {
        if (IsEmpty()) return;
        Node current = Head;
        while (current.Next?.Next != null)
        {
            current = current.Next;
        }
        current.Next = null;
        Tail = current;
        --Size;
        if (IsEmpty()) Head = null;
    }

    public int? First() => IsEmpty() ? null : Head.Value;
    public int? Last() => IsEmpty() ? null : Tail.Value;
}