namespace Leetcode.Hard.TwoPointers;

public class SubstringWithConcatenationOfAllWords {
    public IList<int> FindSubstring(string s, string[] words) {
        var result = new List<int>();
        if (s.Length == 0 || words.Length == 0) return result;

        int wordLen = words[0].Length, 
            totalLen = wordLen * words.Length;

        var wordMap = new Dictionary<string, int>();
        foreach(string word in words) {
            wordMap[word] = wordMap.GetValueOrDefault(word) + 1;
        }

        for(int i = 0; i < wordLen; i++) {
            int left = i, count = 0;
            var windowMap = new Dictionary<string, int>();

            for(int right = i; right + wordLen <= s.Length; right += wordLen) {
                string word = s.Substring(right, wordLen);

                if(!wordMap.ContainsKey(word)) {
                    windowMap.Clear();
                    count = 0;
                    left = right + wordLen;
                } else {
                    windowMap[word] = windowMap.GetValueOrDefault(word) + 1;
                    count++;

                    while(windowMap[word] > wordMap[word]) {
                        string leftWord = s.Substring(left, wordLen);
                        windowMap[leftWord]--;
                        count--;
                        left += wordLen;
                    }

                    if(count == words.Length) 
                        result.Add(left);
                }
            }
        }

        return result;
    }
}