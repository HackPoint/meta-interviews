namespace Leetcode.Easy.Strings;

public class RemoveAllAdjacentDuplicatesInString
{
    public string RemoveDuplicates(string s)
    {
        var a = s.ToCharArray();  // we reuse this for output — O(N) space
        var index = 0;

        foreach (var c in s)
        {
            a[index] = c;   // place current char at write index
            index++;        // advance write pointer

            if (index > 1 && a[index - 1] == a[index - 2])
            {
                index -= 2; // collapse the last two (adjacent dupes)
            }
        }

        return new string(a, 0, index); // return only the written part
    }
}