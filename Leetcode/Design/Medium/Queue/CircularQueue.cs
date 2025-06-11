namespace Leetcode.Design.Easy;

public class MyCircularQueue
{
    private int _front;
    private int _rear;
    private int _count;
    private int[] _queue;

    public MyCircularQueue(int k)
    {
        _queue = new int[k];
    }

    public bool EnQueue(int value)
    {
        if (IsFull()) return false;
        _queue[_rear] = value;
        _rear = (_rear + 1) % _queue.Length;
        _count++;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty()) return false;
        _front = (_front + 1) % _queue.Length;
        _count--;
        return true;
    }

    public int Front()
    {
        return IsEmpty() ? -1 : _queue[_front];
    }

    public int Rear()
    {
        if (!IsEmpty())
            return _queue[(_rear - 1 + _queue.Length) % _queue.Length];
        return -1;
    }

    public bool IsEmpty() => _count == 0;

    public bool IsFull() => _count == _queue.Length;
}