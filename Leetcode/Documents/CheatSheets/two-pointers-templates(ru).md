Отлично. Вот твой полный справочник:
**📘 Все основные шаблоны (шаблоны кода) для двух указателей и их вариаций**, с пояснениями, когда и как применять.

---

## 🧭 Полная карта шаблонов Two Pointers:

---

### 🟢 **1. Converging Two Pointers**

**➤ Когда:** проверка симметрии, палиндром, переворот
**➤ Примеры:** 125. Valid Palindrome, 344. Reverse String

```csharp
int left = 0, right = arr.Length - 1;
while (left < right) {
    // обработка: сравнение, обмен
    left++;
    right--;
}
```

---

### 🟡 **2. Sliding Window (Variable Size)**

**➤ Когда:** найдите минимальный/максимальный подмассив по сумме/длине
**➤ Примеры:** 209. Min Size Subarray Sum, 3. Longest Substring

```csharp
int left = 0, sum = 0;
for (int right = 0; right < arr.Length; right++) {
    sum += arr[right];
    while (sum >= target) {
        // обновить min/max длину и сжать окно
        sum -= arr[left];
        left++;
    }
}
```

---

### 🟠 **3. Sliding Window (Fixed Size)**

**➤ Когда:** размер окна заранее известен (например, k-элементов)
**➤ Примеры:** 239. Sliding Window Maximum

```csharp
for (int right = 0; right < arr.Length; right++) {
    // добавить arr[right] в окно
    if (right - left + 1 == k) {
        // обработка окна (добавить в результат)
        // сжать слева
        left++;
    }
}
```

---

### 🔴 **4. Two Pointers for Search (Sorted Arrays)**

**➤ Когда:** массив отсортирован, ищем пару/тройку/четвёрку чисел
**➤ Примеры:** 15. 3Sum, 16. 3Sum Closest, 167. Two Sum II

```csharp
Array.Sort(arr);
for (int i = 0; i < arr.Length - 2; i++) {
    int left = i + 1, right = arr.Length - 1;
    while (left < right) {
        int sum = arr[i] + arr[left] + arr[right];
        // сравнивай sum с target и двигай указатели
    }
}
```

---

### 🟣 **5. Fast/Slow Pointers (Tortoise & Hare)**

**➤ Когда:** Linked List — цикл, середина, n-й с конца
**➤ Примеры:** 141. Cycle Detection, 876. Middle of Linked List

```csharp
ListNode slow = head, fast = head;
while (fast != null && fast.next != null) {
    slow = slow.next;
    fast = fast.next.next;
}
// slow теперь в середине
```

---

### 🟤 **6. Two Pointers for Removal in-place**

**➤ Когда:** удаление элементов из массива без выделения памяти
**➤ Примеры:** 26. Remove Duplicates from Sorted Array

```csharp
int write = 0;
for (int read = 0; read < arr.Length; read++) {
    if (arr[read] != arr[write - 1]) {
        arr[write] = arr[read];
        write++;
    }
}
```

---

### ⚪ **7. Boyer-Moore Voting Algorithm**

**➤ Когда:** найти доминирующий элемент (встречается > n/2)
**➤ Примеры:** 169. Majority Element

```csharp
int candidate = 0, count = 0;
foreach (int num in nums) {
    if (count == 0)
        candidate = num;
    count += (num == candidate) ? 1 : -1;
}
return candidate;
```

---

### 🔘 **8. Expanding Around Center**

**➤ Когда:** палиндромы, подстроки одинаковые слева/справа
**➤ Примеры:** 5. Longest Palindromic Substring

```csharp
for (int center = 0; center < s.Length * 2 - 1; center++) {
    int left = center / 2;
    int right = left + (center % 2);
    while (left >= 0 && right < s.Length && s[left] == s[right]) {
        // расширяй
        left--;
        right++;
    }
}
```

---
### 🔘 **9. In-place Write Pointer (a.k.a. Read/Write Two Pointers)**

**➤ Когда:** палиндромы, подстроки одинаковые слева/справа
**➤ Примеры:** 5. Longest Palindromic Substring
```csharp
int write = 0;
for (int read = 0; read < arr.Length; read++) {
    if (/* условие, по которому элемент должен остаться */) {
        arr[write] = arr[read];
        write++;
    }
}
// write = новая длина массива
```

## 📝 Алгоритмы, которые включаем (подтверди или добавь):

1. Converging Pointers
2. Sliding Window (Fixed Size)
3. Sliding Window (Variable Size)
4. Sorted Array Search (2Sum/3Sum/4Sum)
5. Fast/Slow (Tortoise & Hare)
6. In-Place Removal (Two Pointers Write/Read)
7. Boyer-Moore Voting
8. Expand Around Center
9. Greedy Window (скобки / интервалы)




