namespace Leetcode.Medium.Arrays.Digits;

public class CompressDigitsAndLetters
{
    public int Compress(char[] chars)
    {
        int read = 0;
        int write = 0;

        while (read < chars.Length)
        {
            char current = chars[read];
            int count = 0;

            // считаем количество повторений
            while (read < chars.Length && chars[read] == current)
            {
                count++;
                read++;
            }

            chars[write++] = current; // пишем символ

            if (count > 1)
            {
                foreach (char c in count.ToString())
                    chars[write++] = c; // пишем цифры count
            }
        }

        return write;
    }
}