DoublyLinkedList list = new DoublyLinkedList();
list.AddLast(1);
list.AddLast(2);
list.AddLast(3);
list.AddLast(4);
list.Insert(5, 3);
list.RemoveAnywhere(1);
list.Display();

public class DoublyLinkedList
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(int value, Node next, Node prev)
        {
            Value = value;
            Next = next;
            Previous = prev;
        }
    }

    public int Size { get; set; }
    public Node Head { get; set; }
    public Node Tail { get; set; }

    public bool IsEmpty() => Size == 0;

    public void AddLast(int value)
    {
        Node newest = new Node(value, null, null);
        if (IsEmpty())
        {
            Tail = newest;
            Head = newest;
        }
        else
        {
            Tail.Next = newest;
            newest.Previous = Tail;
            Tail = newest;
        }
        ++Size;
    }

    public void AddFirst(int value)
    {
        Node newest = new Node(value, null, null);
        if (IsEmpty())
        {
            Tail = newest;
            Head = newest;
        }
        else
        {
            newest.Next = Head;
            Head.Previous = newest;
            Head = newest;
        }
        ++Size;
    }

    public void Insert(int value, int position)
    {
        Node newest = new Node(value, null, null);

        Node current = Head;
        for (int i = 1; i < position - 1; ++i)
        {
            current = current.Next;
        }

        newest.Previous = current;
        newest.Next = current.Next;
        current.Next = newest;
        newest.Next.Previous = newest;
        ++Size;
    }

    public void DeleteFirst()
    {
        if (IsEmpty()) return;

        Head = Head.Next;
        Head.Previous = null;

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

        Tail = Tail.Previous;
        Tail.Next = null;
        --Size;

        if (IsEmpty())
        {
            Head = null;
            Tail = null;
        }


    }

    public void RemoveAnywhere(int position)
    {
        if (IsEmpty()) return;
        Node current = Head;

        for (int i = 1; i < position - 1; ++i)
        {
            current = current.Next;
        }

        current.Next = current.Next.Next;
        current.Next.Previous = current;
        --Size;
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
}