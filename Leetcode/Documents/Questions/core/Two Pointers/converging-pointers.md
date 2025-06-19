## ✅ 5 новых задач для практики Converging Pointers

(**все лёгкие**, и **ты их ещё не делал**)

| № | Задача                                                                                       | Ссылка                                                 | Что отрабатывается |
|---|----------------------------------------------------------------------------------------------|--------------------------------------------------------|--------------------|
| 1 | [917. Reverse Only Letters](https://leetcode.com/problems/reverse-only-letters/)             | 🔁 Только буквы в строке, остальное оставляем на месте |                    |
| 2 | [844. Backspace String Compare](https://leetcode.com/problems/backspace-string-compare/)     | 🔁 Сравнение строк с `#` с конца к центру              |                    |
| 3 | [680. Valid Palindrome II](https://leetcode.com/problems/valid-palindrome-ii/)               | ✅ Можно удалить один символ — **расширение 125**       |                    |
| 4 | [345. Reverse Vowels of a String](https://leetcode.com/problems/reverse-vowels-of-a-string/) | 🔁 Меняем местами только гласные                       |                    |
| 5 | [1768. Merge Strings Alternately](https://leetcode.com/problems/merge-strings-alternately/)  | 🔁 Два указателя с двух строк (обратное слияние)       |                    |

---
## ✅ Цель:

* Пройти все 5 задач
* На каждой — использовать строго **Converging Pointers**
* Следовать нашему чеклисту (анализ → стратегия → реализация)

---

Хочешь начать с **917. Reverse Only Letters**?
Я спрошу по чеклисту — и веду тебя шаг за шагом, пока ты сам не сформулируешь.
---
|  № | Название                                  | Сложность | Ссылка                                                                            | Шаблон                      | Описание                                                                                                         |
| -: | :---------------------------------------- | :-------- | :-------------------------------------------------------------------------------- | :-------------------------- | :--------------------------------------------------------------------------------------------------------------- |
|  1 | Permutation in String                     | 🟦 Medium | [567 🔗](https://leetcode.com/problems/permutation-in-string/)                    | Sliding Window + HashMap    | Проверить, содержит ли строка `s2` любую перестановку `s1`. Окно с частотами символов, сравнение на каждом шаге. |
|  2 | Subarray Product Less Than K              | 🟦 Medium | [713 🔗](https://leetcode.com/problems/subarray-product-less-than-k/)             | Two Pointers (умножение)    | Подсчитать все подмассивы с произведением `< k`. Сдвигаем левую границу, если произведение слишком большое.      |
|  3 | Container With Most Water                 | 🟦 Medium | [11 🔗](https://leetcode.com/problems/container-with-most-water/)                 | Converging Pointers         | Найти максимум "воды" между двумя линиями. Указатели с краёв, движутся к центру.                                 |
|  4 | Sort Colors                               | 🟦 Medium | [75 🔗](https://leetcode.com/problems/sort-colors/)                               | Dutch Flag (3 указателя)    | Сортировка 0, 1, 2 in-place. Используем low/mid/high указатели.                                                  |
|  5 | Trapping Rain Water                       | 🔴 Hard   | [42 🔗](https://leetcode.com/problems/trapping-rain-water/)                       | Two Pointers + PrefixMax    | Подсчёт воды между стенками. Без доп. памяти — два указателя + текущие max'ы слева и справа.                     |
|  6 | Minimum Window Substring                  | 🔴 Hard   | [76 🔗](https://leetcode.com/problems/minimum-window-substring/)                  | Sliding Window + Частоты    | Найти минимальное окно, содержащее все символы другой строки. Расширяем и сжимаем окно, обновляя map.            |
|  7 | Substring with Concatenation of All Words | 🔴 Hard   | [30 🔗](https://leetcode.com/problems/substring-with-concatenation-of-all-words/) | Fixed Window + Словарь слов | Подстроки фиксированной длины, каждый раз сдвигаем окно на `word.Length`, сверяем map слов.                      |
