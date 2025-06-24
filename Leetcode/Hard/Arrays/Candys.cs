namespace Leetcode.Hard.Arrays;

public class Candys
{
    public int Candy(int[] ratings)
    {
        int n = ratings.Length;
        if (n == 1) 
            return 1;

        // Спецслучай: все рейтинги равны
        bool allEqual = true;
        for (int idx = 1; idx < n; idx++)
        {
            if (ratings[idx] != ratings[0])
            {
                allEqual = false;
                break;
            }
        }
        if (allEqual)
            return n;

        // Основной алгоритм
        Span<int> candies = stackalloc int[n];
        for (int i = 0; i < n; i++)
            candies[i] = 1;

        // Проход слева → направо: просто учитываем левый сосед
        for (int i = 1; i < n; i++)
        {
            if (ratings[i] > ratings[i - 1])
                candies[i] = candies[i - 1] + 1;
        }

        // Проход справа ← налево: учитываем правого соседа
        for (int i = n - 1; i >= 1; i--)
        {
            if (ratings[i - 1] > ratings[i] && candies[i - 1] <= candies[i])
                candies[i - 1] = candies[i] + 1;
        }

        // Подсчёт суммы
        int sum = 0;
        for (int i = 0; i < n; i++)
            sum += candies[i];

        return sum;
    }
}