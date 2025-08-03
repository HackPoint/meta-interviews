using Leetcode.Easy.DFS;
using Xunit;

namespace Leetcode.Medium.Stack;


/// <summary>
/// Problem:
/// Given a Unix-style absolute file path, simplify it to its canonical form.
/// The path may contain '.', '..', extra slashes, or redundant components.
///
/// Approach:
/// - Use a stack to simulate directory traversal.
/// - Split the input path by '/' to extract directory segments.
/// - Iterate through each segment:
///     - Ignore empty segments and '.' (current directory).
///     - If segment is '..':
///         - Pop from stack if not empty (go up one level).
///         - If stack is empty, remain at root (do nothing).
///     - Otherwise, push the segment to the stack (it's a valid folder).
/// - After processing, rebuild the path by joining stack elements with '/'.
/// - Since stack is LIFO, reverse it before joining to get correct path order.
///
/// Edge Cases:
/// - Input: "/../" → Output: "/" (cannot go above root)
/// - Input: "/a//b////c/d//././/.." → Output: "/a/b/c"
/// - Empty segments caused by multiple slashes must be ignored
///
/// Time Complexity: O(n)
/// - One pass through the input string; each segment processed once
///
/// Space Complexity: O(m)
/// - Stack may store up to m valid directory segments
///   (where m ≤ number of path components)
/// </summary>
public class SimplifyPaths {
    public string SimplifyPath(string path) {
        string[] paths = path.Split(Path.DirectorySeparatorChar);
        var stack = new Stack<string>();
        foreach (var p in paths) {
            if (p == ".." && stack.Count > 0) {
                stack.Pop();
            }
            else if (p == "." || p == string.Empty) {
                // should ignore
                continue;
            }
            else if (p != "..") {
                stack.Push(p);
            }
        }

        var res = stack.ToArray();
        Array.Reverse(res);
        return $"/{string.Join("/", res)}";
    }
}

public class SimplifyPathTests {
    [Theory]
    [InlineData("/home/", "/home")]
    [InlineData("/../", "/")]
    [InlineData("/home//foo/", "/home/foo")]
    [InlineData("/a/./b/../../c/", "/c")]
    [InlineData("/a/../../b/../c//.//", "/c")]
    [InlineData("/a//b////c/d//././/..", "/a/b/c")]
    [InlineData("/", "/")]
    [InlineData("/..hidden", "/..hidden")]
    [InlineData("/.../", "/...")]
    [InlineData("/./", "/")]
    [InlineData("/a/./b/./c/./d/", "/a/b/c/d")]
    [InlineData("/a/b/c/../../../", "/")]
    [InlineData("/a/b/../../../../c", "/c")]
    public void SimplifyPath_ReturnsExpectedResult(string input, string expected) {
        var solution = new SimplifyPaths();
        var result = solution.SimplifyPath(input);
        Assert.Equal(expected, result);
    }
}