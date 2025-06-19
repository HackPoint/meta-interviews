namespace Leetcode.Easy.Strings;

public class ReverseOnlyLetterss
{
    public string ReverseOnlyLetters(string s) {
        int left = 0, right = s.Length - 1;
        char[] chars = s.ToCharArray();
        while(left < right) {
            if(!char.IsLetter(chars[left])) {
                left++;
                continue;
            }

            if(!char.IsLetter(chars[right])) {
                right--;
                continue;
            }

            if(char.IsLetter(chars[left]) && char.IsLetter(chars[right])) {
               
                Swap(chars, left, right);
                left++;
                right--;
            }
            
        }
        return new string(chars);
    }

    private void Swap(char[] arr, int i, int j) {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}