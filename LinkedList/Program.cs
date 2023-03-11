
LinkedList list = new();
list.AddLast(1);
list.AddLast(2);
list.AddLast(3);
list.AddLast(5);
list.InsertSorted(4);
list.Display();
Console.WriteLine(list.Find(3));


public class LinkedList
{
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value, Node next)
        {
            Value = value;
            Next = next;
        }
    }

    private Node? Head { get; set; }
    private Node? Tail { get; set; }
    public int Size { get; private set; }

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

    public void InsertSorted(int value)
    {
        Node newest = new Node(value, null);
        if (IsEmpty())
            Head = newest;
        else
        {
            Node p = Head;
            Node q = Head;
            while (p != null && value > p.Value)
            {
                q = p;
                p = p.Next;
            }

            if (p == Head)
            {
                newest.Next = Head;
                Head = newest;
            }
            else
            {
                newest.Next = q.Next;
                q.Next = newest;
            }
        }
        ++Size;
    }

    public void Display()
    {
        Node current = Head;
        while(current != null)
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

    public void Insert(int value, int index)
    {
        if (index <= 0 || index >= Size)
        {
            Console.WriteLine("invalid index");
            return;
        }

        Node newest = new Node(value, null);
        Node current = Head;
        int i = 1;
        while (i < index - 1)
        {
            current = current.Next;
            ++i;
        }

        newest.Next = current.Next;
        current.Next = newest;
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

    public void RemoveAny(int position)
    {
        Node current = Head;
        int i = 1;
        while (i < position - 1)
        {
            current = current.Next;
            ++i;
        }

        current.Next = current.Next.Next;
        --Size;
    }

    public int Find(int value)
    {
        Node current = Head;
        int i = 1;
        while (current.Next != null)
        {
            if (current.Value == value)
                return i;
            current = current.Next;
            ++i;
        }

        return -1;
    }
}