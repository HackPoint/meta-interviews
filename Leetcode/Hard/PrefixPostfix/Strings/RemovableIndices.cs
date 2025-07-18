namespace Leetcode.Hard.PrefixPostfix.Strings;

public class RemovableIndices {
    public static List<int> GetRemovableIndices(string str1, string str2) {
        List<int> removableIndices = new List<int>();

        int n1 = str1.Length;
        int n2 = str2.Length;

        // 1. Calculate 'pre': This is the length of the longest common prefix between str1 and str2.
        // It also represents the first index in str1 where a mismatch with str2 occurs,
        // or n2 if str2 is a prefix of str1.
        int pre = 0;
        while (pre < n2 && str1[pre] == str2[pre]) {
            pre++;
        }

        // 2. Calculate 'post': This is the length of the longest common suffix between str1 and str2.
        // We compare characters from the end of both strings.
        int post = 0;
        // The loop condition ensures we don't go out of bounds for either string
        // and compare only up to n2 characters (since str2 is the shorter string).
        while (post < n2 && str1[n1 - 1 - post] == str2[n2 - 1 - post]) {
            post++;
        }

        // Determine the range of possible removable indices.
        // An index 'i' in str1 is removable if:
        // a) The prefix str1[0...i-1] matches str2[0...i-1].
        //    This means 'i' must be less than or equal to 'pre'.
        // b) The suffix str1[i+1...n1-1] matches str2[i...n2-1].
        //    This means the starting index of the matching suffix in str1 (which is n1 - post)
        //    must be less than or equal to 'i+1'. So, 'i' must be at least 'n1 - post - 1'.

        int startIndex = n1 - 1 - post; // The earliest possible index that can be removed
        int endIndex = pre; // The latest possible index that can be removed

        // Iterate through the determined range and add indices to the result list.
        // If startIndex > endIndex, it means the common prefix and common suffix regions
        // either overlap too much or do not meet, indicating no single character removal
        // can make str1 equal to str2.
        if (startIndex <= endIndex) {
            for (int i = startIndex; i <= endIndex; i++) {
                removableIndices.Add(i);
            }
        }

        // If no removable indices were found (list is empty), return [-1] as per problem statement.
        if (removableIndices.Count == 0) {
            return new List<int> { -1 };
        }
        else {
            return removableIndices;
        }
    }
}