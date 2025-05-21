// ThreeSum([-1, 0, 1, 2, -1, -4]);
// Console.WriteLine(LongestPalindrome("babad"));
// Console.WriteLine(LongestPalindrome("a"));

// Console.WriteLine(SingleNumber([4, 1, 2, 1, 2]));

// Console.WriteLine(MaxSubArray([-2, 1, -3, 4, -1, 2, 1, -5, 4]));
Console.WriteLine(MaxArea( [1,8,6,2,5,4,8,3,7]));

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

//LongestPalindrome
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

// ThreeSum
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