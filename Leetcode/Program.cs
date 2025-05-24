using System.Text;
using Leetcode;
using Leetcode.Backtracking;
using Leetcode.TwoPointers;

// ThreeSum([-1, 0, 1, 2, -1, -4]);
// Console.WriteLine(LongestPalindrome("babad"));
// Console.WriteLine(LongestPalindrome("a"));
// Console.WriteLine(SingleNumber([4, 1, 2, 1, 2]));
// Console.WriteLine(MaxSubArray([-2, 1, -3, 4, -1, 2, 1, -5, 4]));
// Console.WriteLine(MaxArea( [1,8,6,2,5,4,8,3,7]));
// Console.WriteLine(MinWindow("ADOBECODEBANC", "ABC"));
// GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]);
// LetterCombinations("23");
//var letterCombinations = new LetterCombinationsPerformanceImprovement();
//letterCombinations.LetterCombinations("23");
// TrapWater trapWater = new TrapWater();
// Console.WriteLine(trapWater.Trap([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]));
// Console.WriteLine(trapWater.Trap([4, 2, 0, 3, 2, 5]));
/*
LinkedLists linkedLists = new LinkedLists();

var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));



var result = linkedLists.AddTwoNumbers(l1, l2);
linkedLists.PrintList(l1);
linkedLists.PrintList(l2);
linkedLists.PrintList(result);
*/

// Console.WriteLine(LongestValidParentheses("(()"));
// Console.WriteLine(LongestValidParentheses("(()))())("));

Console.WriteLine(FindAnagrams("cbaebabacd", "abc"));

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
   Input: strs = ["eat","tea","tan","ate","nat","bat"]
   Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
 */
IList<IList<string>> GroupAnagrams(string[] strs)
{
    var map = new Dictionary<string, List<string>>();
    Span<int> freq = stackalloc int[26];

    foreach (var word in strs)
    {
        freq.Clear();

        foreach (char c in word)
            freq[c - 'a']++;

        // Convert the freq span to a unique key string
        var keyBuilder = new StringBuilder(52);
        for (int i = 0; i < 26; i++)
        {
            keyBuilder.Append(freq[i]);
            keyBuilder.Append(',');
        }

        string key = keyBuilder.ToString();

        if (!map.TryGetValue(key, out var list))
        {
            list = new List<string>();
            map[key] = list;
        }

        list.Add(word);
    }

    return map.Values.ToList<IList<string>>();
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


/*
 * Input: n=3
 * Output: ["((()))","(()())","(())()","()(())","()()()"]
 */
// GenerateParenthesis(3);
IList<string> GenerateParenthesis(int n)
{
    IList<string> result = new List<string>();
    Backtrack(new StringBuilder(), 0, 0, n, result);
    Console.WriteLine(string.Join("\n", result.Select(list => "[" + string.Join(", ", list) + "]")));
    return result;
}

void Backtrack(StringBuilder sb, int open, int close, int depth, IList<string> result)
{
    if (sb.Length == 2 * depth)
    {
        result.Add(sb.ToString());
        return;
    }

    if (open < depth)
    {
        sb.Append('(');
        Backtrack(sb, open + 1, close, depth, result);
        sb.Length--;
    }

    if (close < open)
    {
        sb.Append(')');
        Backtrack(sb, open, close + 1, depth, result);
        sb.Length--;
    }
}


int MaxArea(int[] height)
{
    int maxArea = 0;
    int left = 0, right = height.Length - 1;

    while (left < right)
    {
        int h = Math.Min(height[left], height[right]);
        int w = right - left;
        int area = h * w;
        maxArea = Math.Max(maxArea, area);

        if (height[left] < height[right])
        {
            left++;
        }
        else
        {
            right--;
        }
    }

    return maxArea;
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

int FindDuplicate(int[] nums)
{
    int slow = nums[0];
    int fast = nums[0];

    do
    {
        slow = nums[slow];
        fast = nums[nums[fast]];
    } while (fast != slow);

    slow = nums[0];

    while (slow != fast)
    {
        slow = nums[slow];
        fast = nums[fast];
    }

    return slow;
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

int SingleNumber(int[] nums)
{
    int ones = 0, twos = 0;

    foreach (int i in nums)
    {
        twos = twos | (ones & i);
        ones = ones ^ i;
        int common = ones & twos;

        ones &= ~common;
        twos &= ~common;
    }

    return ones;
}

string LongestPalindrome(string s)
{
    int startIndex = 0, maxLen = 0;

    for (int i = 0; i < s.Length; ++i)
    {
        int len1 = ExpandAroundCenter(s, i, i);
        int len2 = ExpandAroundCenter(s, i, i + 1);
        int len = Math.Max(len1, len2);

        if (len > maxLen)
        {
            maxLen = len;
            startIndex = i - (len - 1) / 2;
        }
    }

    return s.Substring(startIndex, maxLen);
}

int ExpandAroundCenter(string s, int left, int right)
{
    while (left >= 0 && right < s.Length && s[left] == s[right])
    {
        left--;
        right++;
    }

    return right - left - 1;
}

IList<IList<int>> ThreeSum(int[] nums)
{
    List<IList<int>> result = new List<IList<int>>();
    Array.Sort(nums);
    for (int i = 0; i < nums.Length; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1]) continue;

        int left = i + 1;
        int right = nums.Length - 1;
        while (left < right)
        {
            int sum = nums[i] + nums[left] + nums[right];
            if (sum == 0)
            {
                result.Add(new List<int> { nums[i], nums[left], nums[right] });

                while (left < right && nums[left] == nums[left + 1]) left++;
                while (left < right && nums[right] == nums[right - 1]) right--;

                left++;
                right--;
            }
            else if (sum < 0)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
    }

    // Console.WriteLine(string.Join("\n", result.Select(list => "[" + string.Join(", ", list) + "]")));
    return result;
}