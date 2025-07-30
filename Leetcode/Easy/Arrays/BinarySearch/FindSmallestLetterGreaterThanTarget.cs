using Xunit;

namespace Leetcode.Easy.Arrays.BinarySearch;

public class FindSmallestLetterGreaterThanTarget
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        int left = 0, right = letters.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (letters[mid] <= target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return letters[left % letters.Length];
    }
}

public class FindSmallestLetterGreaterThanTargetTests
{
    [Fact]
    public void Test_RegularCase_ReturnsNextLetter()
    {
        var finder = new FindSmallestLetterGreaterThanTarget();
        char[] letters = { 'c', 'f', 'j' };
        Assert.Equal('f', finder.NextGreatestLetter(letters, 'c'));
    }

    [Fact]
    public void Test_TargetEqualsElement_ReturnsNextLetter()
    {
        var finder = new FindSmallestLetterGreaterThanTarget();
        char[] letters = { 'c', 'f', 'j' };
        Assert.Equal('j', finder.NextGreatestLetter(letters, 'f'));
    }

    [Fact]
    public void Test_TargetGreaterThanAll_ReturnsFirstLetter()
    {
        var finder = new FindSmallestLetterGreaterThanTarget();
        char[] letters = { 'c', 'f', 'j' };
        Assert.Equal('c', finder.NextGreatestLetter(letters, 'j'));
    }

    [Fact]
    public void Test_WrapAroundTargetBeyondLast_ReturnsFirst()
    {
        var finder = new FindSmallestLetterGreaterThanTarget();
        char[] letters = { 'a', 'b' };
        Assert.Equal('a', finder.NextGreatestLetter(letters, 'z'));
    }

    [Fact]
    public void Test_WithDuplicates_StillReturnsCorrect()
    {
        var finder = new FindSmallestLetterGreaterThanTarget();
        char[] letters = { 'e', 'e', 'e', 'k', 'q', 'q', 'q' };
        Assert.Equal('k', finder.NextGreatestLetter(letters, 'e'));
    }

    [Fact]
    public void Test_SingleElement_WrapsAround()
    {
        var finder = new FindSmallestLetterGreaterThanTarget();
        char[] letters = { 'z' };
        Assert.Equal('z', finder.NextGreatestLetter(letters, 'a'));
    }
}