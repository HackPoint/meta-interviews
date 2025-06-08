using Leetcode.Hard.DP;

MaxSumOfSubsequenceWithNonAdjacentElements adjacentElements
    = new MaxSumOfSubsequenceWithNonAdjacentElements();

adjacentElements.MaximumSumSubsequence([0, 3, 3, 3, 1, -2], [[4, 0], [1, 0]]);

IList<int> FindAnagrams(string s, string p)
{
    var result = new List<int>();
    if (s.Length < p.Length) return result;
    Span<int> need = stackalloc int[26];
    Span<int> window = stackalloc int[26];
    int left = 0;

    foreach (char c in p)
        need[c - 'a']++;

    for (int right = 0; right < s.Length; right++)
    {
        window[s[right] - 'a']++;

        if (right - left + 1 > p.Length)
        {
            window[s[left] - 'a']--;
            left++;
        }

        if (right - left + 1 == p.Length && window.SequenceEqual(need))
        {
            result.Add(left);
        }
    }

    Console.WriteLine(string.Join("\n", result.Select(list => "[" + string.Join(", ", list) + "]")));
    return result;
}

int LongestValidParentheses(string s)
{
    char open = '(';
    int maxLength = 0;
    var stack = new Stack<int>();
    stack.Push(-1);
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == open)
        {
            stack.Push(i);
        }
        else
        {
            stack.Pop();
            if (stack.Count == 0)
            {
                stack.Push(i);
            }
            else
            {
                maxLength = Math.Max(maxLength, i - stack.Peek());
            }
        }
    }

    return maxLength;
}

/*
 * Input: digits = "23"
   Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
 */
IList<string> LetterCombinations(string digits)
{
    if (string.IsNullOrEmpty(digits)) return [];
    var result = new List<string>();
    Span<char> freq = stackalloc char[digits.Length];
    var map = new[]
    {
        "", "", "abc", "def", "ghi", "jkl",
        "mno", "pqrs", "tuv", "wxyz"
    };

    BacktrackPhoneCombinations(0, digits, freq, map, result);
    Console.WriteLine(string.Join("\n", result.Select(list => "[" + string.Join(", ", list) + "]")));
    return result;
}

void BacktrackPhoneCombinations(int index, string digits, Span<char> buffer, string[] map, IList<string> result)
{
    if (index == digits.Length)
    {
        result.Add(new string(buffer));
        return;
    }

    var letters = map[digits[index] - '0'];
    foreach (var letter in letters)
    {
        buffer[index] = letter;
        BacktrackPhoneCombinations(index + 1, digits, buffer, map, result);
    }
}


/*
   Input: s = "ADOBECODEBANC", t = "ABC"
   Output: "BANC"
   Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
   Approach: Sliding window
 */
string MinWindow(string s, string t)
{
    if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length)
        return "";

    var need = new Dictionary<char, int>();
    foreach (char c in t)
    {
        need.TryAdd(c, 0);
        need[c]++;
    }

    var have = new Dictionary<char, int>();
    int required = need.Count;
    int formed = 0;
    int left = 0, right = 0;
    int minLen = int.MaxValue;
    int start = 0;

    while (right < s.Length)
    {
        char c = s[right];
        have.TryAdd(c, 0);
        have[c]++;

        if (need.ContainsKey(c) && have[c] == need[c])
        {
            formed++;
        }

        while (formed == required)
        {
            if (right - left + 1 < minLen)
            {
                minLen = right - left + 1;
                start = left;
            }

            char leftChar = s[left];
            have[leftChar]--;

            if (need.ContainsKey(leftChar) && have[leftChar] < need[leftChar])
            {
                formed--;
            }

            left++;
        }

        right++;
    }

    return minLen == int.MaxValue ? "" : s.Substring(start, minLen);
}


int MaxSubArray(int[] nums)
{
    int maxSum = int.MinValue;
    int currentSum = 0;

    foreach (int num in nums)
    {
        currentSum += num;
        maxSum = Math.Max(currentSum, maxSum);
        if (currentSum < 0)
        {
            currentSum = 0;
        }
    }

    return maxSum;
}


bool IsPalindrome(string s)
{
    int left = 0, right = s.Length - 1;

    while (left < right)
    {
        while (left < right && !char.IsLetterOrDigit(s[left])) left++;
        while (left < right && !char.IsLetterOrDigit(s[right])) right--;

        if (char.ToLower(s[left]) != char.ToLower(s[right]))
            return false;

        left++;
        right--;
    }

    return true;
}