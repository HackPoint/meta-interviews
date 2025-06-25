namespace Leetcode.Design.Easy.Stack;

public class OnlyStacksQueue
{
    private readonly Stack<int> _output = new();
    private readonly Stack<int> _input = new();

    public void Push(int x)
    {
        _input.Push(x);
    }

    public int Pop()
    {
         Peek();
         return _output.Pop();
    }

    public int Peek()
    {
        if (_output.Count == 0)
        {
            while (_input.Count > 0)
                _output.Push(_input.Pop());
        }

        return _output.Peek();
    }

    public bool Empty()
    {
        return _input.Count == 0 && _output.Count == 0;
    }
}