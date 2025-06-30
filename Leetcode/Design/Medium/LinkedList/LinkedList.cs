namespace Leetcode.Design.Medium.LinkedList;

public class MyLinkedList
{
    private Node _head;
    private Node _tail;
    private int _size;

    public MyLinkedList()
    {
    }

    public int Get(int index)
    {
        if (index < 0 || _size <= index) return -1;

        var node = _head;
        if (index < _size / 2)
        {
            for (int i = 0; i < index; i++)
                node = node.Next;
        }
        else
        {
            node = _tail;
            for (int i = _size - 1; i > index; i--)
                node = node.Prev;
        }

        return node.Value;
    }

    public void AddAtHead(int val)
    {
        if (_head == null && _tail == null)
        {
            var newNode = new Node(val);
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            var oldHead = _head;
            if (oldHead != null)
            {
                var newNode = new Node(val)
                {
                    Next = oldHead
                };
                oldHead.Prev = newNode;
                _head = newNode;
            }
        }

        _size++;
    }

    public void AddAtTail(int val)
    {
        var newNode = new Node(val);
        if (_head == null && _tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }

        _size++;
    }

    public void AddAtIndex(int index, int val)
    {
        if (index < 0 || index > _size) return;

        if (index == _size)
        {
            AddAtTail(val);
            return;
        }

        var current = _head;
        if (index < _size / 2)
        {
            for (int i = 0; i < index; i++)
                current = current.Next;
        }
        else
        {
            current = _tail;
            for (int i = _size - 1; i > index; i--)
                current = current.Prev;
        }

        var newNode = new Node(val);
        if (current.Prev != null)
        {
            newNode.Prev = current.Prev;
            newNode.Next = current;
            current.Prev.Next = newNode;
            current.Prev = newNode;
        }
        else
        {
            newNode.Next = current;
            current.Prev = newNode;
            _head = newNode;
        }

        _size++;
    }

    public void DeleteAtIndex(int index)
    {
        if (index < 0 || index >= _size) return;

        var current = _head;
        if (index < _size / 2)
        {
            for (int i = 0; i < index; i++)
                current = current.Next;
        }
        else
        {
            current = _tail;
            for (int i = _size - 1; i > index; i--)
                current = current.Prev;
        }

        if (index == 0)
        {
            _head = _head.Next;
            if (_head != null)
                _head.Prev = null;
        }
        else if (index == _size - 1)
        {
            _tail = _tail.Prev;
            if (_tail != null)
                _tail.Next = null;
        }
        else
        {
            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
        }

        _size--;
    }

    private class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }
    }
}