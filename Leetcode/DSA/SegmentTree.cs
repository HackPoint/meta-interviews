namespace Leetcode.DSA;

public class SegmentTree
{
    private readonly SegmentNode[] _tree;
    private readonly int _n;

    public SegmentTree(int[] nums)
    {
        _n = nums.Length;
        _tree = new SegmentNode[4 * _n];
        Build(nums, 0, 0, _n - 1);
    }

    private void Build(int[] nums, int node, int l, int r)
    {
        if (l == r)
        {
            _tree[node] = new SegmentNode(nums[l]);
            return;
        }

        int m = (l + r) / 2;
        Build(nums, 2 * node + 1, l, m);
        Build(nums, 2 * node + 2, m + 1, r);
        _tree[node] = SegmentNode.Merge(_tree[2 * node + 1], _tree[2 * node + 2]);
    }

    public void Update(int index, int value) => Update(0, 0, _n - 1, index, value);

    private void Update(int node, int l, int r, int index, int value)
    {
        if (l == r)
        {
            _tree[node] = new SegmentNode(value);
            return;
        }

        int m = (l + r) / 2;
        if (index <= m)
            Update(2 * node + 1, l, m, index, value);
        else
            Update(2 * node + 2, m + 1, r, index, value);

        _tree[node] = SegmentNode.Merge(_tree[2 * node + 1], _tree[2 * node + 2]);
    }

    public long Query() => _tree[0].Max();
}

public class SegmentNode
{
    private readonly long[,] _dp = new long[2, 2];

    public SegmentNode(int val)
    {
        _dp[0, 0] = 0;
        _dp[0, 1] = long.MinValue;
        _dp[1, 0] = long.MinValue;
        _dp[1, 1] = val;
    }

    private SegmentNode()
    {
        for (int i = 0; i < 2; i++)
        for (int j = 0; j < 2; j++)
            _dp[i, j] = long.MinValue;
    }

    public static SegmentNode Merge(SegmentNode left, SegmentNode right)
    {
        var res = new SegmentNode();

        for (int l1 = 0; l1 <= 1; l1++)
        for (int r1 = 0; r1 <= 1; r1++)
        for (int l2 = 0; l2 <= 1; l2++)
        for (int r2 = 0; r2 <= 1; r2++)
        {
            if (r1 == 1 && l2 == 1) continue;

            long a = left._dp[l1, r1];
            long b = right._dp[l2, r2];

            if (a != long.MinValue && b != long.MinValue)
                res._dp[l1, r2] = Math.Max(res._dp[l1, r2], a + b);
        }

        return res;
    }

    public long Max()
    {
        long result = long.MinValue;
        for (int i = 0; i < 2; i++)
        for (int j = 0; j < 2; j++)
            if (_dp[i, j] != long.MinValue)
                result = Math.Max(result, _dp[i, j]);
        return result;
    }
}