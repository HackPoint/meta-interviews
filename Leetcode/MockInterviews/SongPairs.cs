using Xunit;

namespace Leetcode.MockInterviews;

public static class SongPairs
{
    /// <summary>
    /// Returns the number of pairs (i < j) such that (time[i] + time[j]) % 60 == 0.
    /// Time: O(n). Space: O(1) extra (fixed-size 60-bucket array).
    /// </summary>
    public static int NumPairsDivisibleBy60(int[] time)
    {
        if (time == null) throw new ArgumentNullException(nameof(time));

        // freq[r] stores how many previous songs had remainder r modulo 60
        int[] freq = new int[60];
        long count = 0; // use long during accumulation to avoid intermediate overflow

        foreach (int t in time)
        {
            int r = t % 60;
            int need = (60 - r) % 60; // pairs: r + need ≡ 0 (mod 60), works for r==0 and r==30 too

            // All previously seen songs with remainder "need" form valid pairs with current song
            count += freq[need];

            // Current song becomes available for future pairings
            freq[r]++;
        }

        // Given constraints, result fits in int; cast defensively.
        if (count > int.MaxValue)
            throw new OverflowException("Pair count exceeds Int32 range.");
        return (int)count;
    }
}
public class SongPairsTests
{
    [Fact]
    public void Example1()
    {
        int[] time = { 30, 20, 150, 100, 40 };
        Assert.Equal(3, SongPairs.NumPairsDivisibleBy60(time));
    }

    [Fact]
    public void Example2()
    {
        int[] time = { 60, 60, 60 };
        Assert.Equal(3, SongPairs.NumPairsDivisibleBy60(time));
    }

    [Fact]
    public void MixedRemainders()
    {
        int[] time = { 10, 50, 20, 40, 30, 90 };
        Assert.Equal(3, SongPairs.NumPairsDivisibleBy60(time)); // (10,50),(20,40),(30,90),(10,110? none),(50,70? none) + (20,100? none)
    }

    [Fact]
    public void LargeValuesHandled()
    {
        int[] time = { 120, 180, 240, 300 }; // all %60==0, choose(4,2)=6
        Assert.Equal(6, SongPairs.NumPairsDivisibleBy60(time));
    }
}