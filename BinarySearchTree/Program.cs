BinarySearchTree bst = new();

public class BinarySearchTree
{
    public class Node
    {
        public int Element { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int element, Node left, Node right)
        {
            Element = element;
            Left = left;
            Right = right;
        }
    }

    public Node Root { get; private set; } = null;

    public void InsertIterative(Node temproot, int element)
    {
        Node temp = null;
        while (temproot != null)
        {
            temp = temproot;
            if (element == temproot.Element)
                return;
            if (element < temproot.Element)
                temproot = temproot.Left;
            else if (element > temproot.Element)
                temproot = temproot.Right;
        }

        Node newest = new(element, null, null);
        if (Root != null)
        {
            if (element < temp.Element)
                temp.Left = newest;
            else if (element > temp.Element)
                temp.Right = newest;
        }
        else
        {
            Root = newest;
        }
    }

    public Node InsertRecursive(Node temproot, int element)
    {
        if (Root == null)
        {
            Root = new Node(element, null, null);
            return Root;
        }

        if (temproot != null)
        {
            if (element < temproot.Element)
                temproot.Left = InsertRecursive(temproot.Left, element);
            else if (element > temproot.Element)
                temproot.Right = InsertRecursive(temproot.Right, element);
        }
        else
        {
            temproot = new Node(element, null, null);
        }
        return temproot;
    }

    public void InorderTraversal(Node temproot)
    {
        if (temproot != null)
        {
            InorderTraversal(temproot.Left);
            Console.Write(temproot.Element + " ");
            InorderTraversal(temproot.Right);
        }
    }

    public void PreorderTraversal(Node temproot)
    {
        if (temproot != null)
        {
            Console.Write(temproot.Element + " ");
            PreorderTraversal(temproot.Left);
            PreorderTraversal(temproot.Right);
        }
    }

    public void PostorderTraversal(Node temproot)
    {
        if (temproot != null)
        {
            PreorderTraversal(temproot.Left);
            PreorderTraversal(temproot.Right);
            Console.Write(temproot.Element + " ");
        }
    }

    public void LevelorderTraversal()
    {
        if (Root == null) return;
        Queue<Node> queue = new Queue<Node>();
        Node temp = Root;
        Console.Write(temp.Element + " ");
        queue.Enqueue(temp);

        while(queue.FirstOrDefault() != null)
        {
            temp = queue.Dequeue();
            if (temp.Left != null)
            {
                Console.Write(temp.Left.Element + " ");
                queue.Enqueue(temp.Left);
            }

            if (temp.Right != null)
            {
                Console.Write(temp.Right.Element + " ");
                queue.Enqueue(temp.Right);
            }
        }
    }

    public bool SearchIterative(int element)
    {
        Node temproot = Root;

        while (temproot != null)
        {
            if (element == temproot.Element)
                return true;

            if (element < temproot.Element)
                temproot = temproot.Left;
            else if (element > temproot.Element)
                temproot = temproot.Right;
        }
        return false;
    }

    public bool SearchRecursive(Node temproot, int element)
    {
        if (temproot != null)
        {
            if (temproot.Element == element)
                return true;

            if (element < temproot.Element)
                SearchRecursive(temproot.Left, element);
            else if (element > temproot.Element)
                SearchRecursive(temproot.Right, element);
        }
        return false;
    }

    public bool Delete(int element)
    {
        Node parent = Root;
        Node parentOfParent = null;

        while (parent != null && parent.Element != element)
        {
            parentOfParent = parent;
            if (element < parent.Element)
                parent = parent.Left;
            else if (element > parent.Element)
                parent = parent.Right;
        }

        if (parent == null) return false;

        if (parent.Left != null && parent.Right != null)
        {
            Node subtree = parent.Left;
            Node parentOfSubtree = parent;
            while (subtree.Right != null)
            {
                parentOfSubtree = subtree;
                subtree = subtree.Right;
            }
            parent.Element = subtree.Element;
            parent = subtree;
            parentOfParent = parentOfSubtree;
        }

        Node c = parent.Left != null ? parent.Left : parent.Right;
        if (parent == Root) Root = null;
        else
        {
            if (parent == parentOfParent.Left)
                parentOfParent.Left = c;
            else
                parentOfParent.Right = c;
        }
        return true;
    }

    public int Count(Node temproot) => temproot != null ? Count(temproot.Left) + Count(temproot.Right) + 1 : 0;
    public int Level(Node temproot)
    {
        if (temproot != null)
        {
            int x = Level(temproot.Left);
            int y = Level(temproot.Right);
            return (x > y ? x : y) + 1;
        }
        return 0;
    }

}
