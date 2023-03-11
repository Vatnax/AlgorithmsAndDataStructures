CircularLinkedList list = new();
list.AddLast(0);
list.AddLast(1);
list.AddLast(2);
list.AddLast(3);
list.AddLast(6);
list.Display();
public class CircularLinkedList
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

    public Node Head { get; set; }
    public Node Tail { get; set; }
    public int Size { get; set; }

    public CircularLinkedList()
    {
        Head = null;
        Tail = null;
        Size = 0;
    }

    public bool IsEmpty() => Size == 0;

    public void Display()
    {
        Node current = Head;
        for (int i = 0; i < Size; ++i)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void AddLast(int value)
    {
        Node newest = new Node(value, null);
        if (IsEmpty())
        {
            newest.Next = newest;
            Head = newest;
        }
        else
        {
            newest.Next = Head;
            Tail.Next = newest;
        }
        Tail = newest;
        ++Size;
    }

    public void AddFirst(int value)
    {
        Node newest = new Node(value, null);
        if (IsEmpty())
        {
            newest.Next = newest;
            Head = newest;
            Tail = newest;
        }
        else
        {
            Tail.Next = newest;
            newest.Next = Head;
            Head = newest;
        }
        ++Size;
    }

    public void Insert(int value, int position)
    {
        Node newest = new Node(value, null);
        Node current = Head;
        for (int i = 1; i < position - 1; ++i)
        {
            current = current.Next;
        }
        newest.Next = current.Next;
        current.Next = newest;
        ++Size;
    }

    public void DeleteFirst()
    {
        if (IsEmpty()) return;

        Tail.Next = Head.Next;
        Head = Head.Next;
        --Size;
        if (IsEmpty())
        {
            Head = null;
            Tail = null;
        }
    }

    public void DeleteLast()
    {
        if (IsEmpty()) return;

        Node current = Head;
        for (int i = 1; i < Size - 1; ++i)
        {
            current = current.Next;
        }

        current.Next.Next = Tail.Next;
        Tail = current;
        --Size;

        if (IsEmpty())
        {
            Head = null;
            Tail = null;
        }
    }

    public void DeleteAnywhere(int position)
    {
        Node current = Head;
        for (int i = 1; i < position - 1; ++i)
        {
            current = current.Next;
        }

        current.Next = current.Next.Next;
        --Size;
    }
}