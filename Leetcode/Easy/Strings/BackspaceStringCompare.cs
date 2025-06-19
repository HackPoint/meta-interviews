namespace Leetcode.Easy.Strings;

public class BackspaceStringCompare
{
    public bool BackspaceCompare(string s, string t) {
        // Инициализируем указатели на конец обеих строк
        int i = s.Length - 1;
        int j = t.Length - 1;

        // Пока хотя бы один указатель не дошёл до начала строки
        while (i >= 0 || j >= 0) {
            // Пропускаем символы, "уничтоженные" с помощью `#`
            NextValidChar(s, ref i);
            NextValidChar(t, ref j);

            // Если оба указателя завершились → строки равны
            if (i == -1 && j == -1) return true;

            // Если один указатель дошёл до начала строки, а другой — нет → не равны
            if (i == -1 || j == -1) return false;

            // Если текущие "живые" символы не совпадают → строки не равны
            if (s[i] != t[j]) return false;

            // Если совпадают — двигаем оба указателя влево
            i--;
            j--;
        }

        // Если сравнили все символы без расхождений
        return true;

        // 🔧 Вспомогательная функция: ищет следующий "живой" символ в строке
        void NextValidChar(string s, ref int index) {
            bool found = false;
            int skip = 0;

            // Двигаемся от текущей позиции к началу
            for (int i = index; i >= 0; i--) {
                if (s[i] == '#') {
                    // Увеличиваем счётчик символов, которые нужно пропустить
                    skip++;
                } else {
                    if (skip > 0) {
                        // Текущий символ уничтожается предыдущим `#`
                        skip--;
                    } else {
                        // Это "живой" символ — сохраняем его позицию
                        index = i;
                        found = true;
                        break;
                    }
                }
            }

            // Если не найдено ни одного "живого" символа — обозначаем завершение
            if (!found) index = -1;
        }
    }

}