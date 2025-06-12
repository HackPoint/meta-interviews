namespace Leetcode.Design.Medium.Stack.MinStack;

public class MinStack
{
    private readonly Stack<int> _main = new();
    private readonly Stack<int> _min = new();
    
    public MinStack()
    {
    }

    public void Push(int val)
    {
        _main.Push(val);
        if (_min.Count > 0)
        {
            var minValue = Math.Min(val, _min.Peek());
            _min.Push(minValue);
        }
        else
        {
            _min.Push(val);
        }
    }

    public void Pop()
    {
        _main.Pop();
        _min.Pop();
    }

    public int Top()
    {
        return _main.Peek();
    }

    public int GetMin()
    {
        return _min.Peek();
    }
}