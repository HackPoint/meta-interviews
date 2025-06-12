namespace Leetcode.Design.Medium.Stack.StackWithIncrementOps;

public class CustomStack
{
    private readonly int _maxSize;
    private readonly int[] _stack;
    private int _count;

    public CustomStack(int maxSize)
    {
        _maxSize = maxSize;
        _stack = new int [maxSize];
        _count = 0;
    }

    public void Push(int x)
    {
        if (_maxSize > _count)
        {
            _stack[_count] = x;
            _count++;
        }
    }

    public int Pop()
    {
        if (_stack.Length == 0) return -1;
        if (_count <= 0) return -1;
        _count--;
        
        int top = _stack[_count];
        _stack[_count] = 0;
        return top;
    }

    public void Increment(int k, int val)
    {
        for (int i = 0; i < Math.Min(k, _count); i++)
        {
            _stack[i] += val;
        }
    }
}