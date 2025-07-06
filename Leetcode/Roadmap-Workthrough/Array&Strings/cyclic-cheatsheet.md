Вот полный **Cyclic Sort Cheat Sheet** — на русском и английском — с шаблонами, условиями, примерами и общими правилами.

---

# 📘 **Cyclic Sort Cheat Sheet** — EN / RU

## 📌 When to Use (Когда применять):

| English                                                     | Русский                                                        |
| ----------------------------------------------------------- | -------------------------------------------------------------- |
| Array of size `n`, elements in range `[1..n]` or `[0..n-1]` | Массив длины `n`, значения в диапазоне `[1..n]` или `[0..n-1]` |
| Need to place each number at its correct index              | Нужно поставить каждое число на “своё место” (`num → index`)   |
| Require **O(n)** time and **O(1)** space                    | Требуется **O(n)** по времени и **O(1)** по памяти             |
| Must detect missing/duplicate/misplaced numbers             | Нужно найти пропущенные / дубликаты / не на месте              |

---

## 🔁 Основной шаблон / Core Template:

```csharp
int i = 0;
while (i < nums.Length)
{
    int correct = nums[i] - 1;
    if (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[correct])
    {
        (nums[i], nums[correct]) = (nums[correct], nums[i]);
    }
    else i++;
}
```

🧠 This will move each number `num` to index `num - 1`, in-place
🧠 Это переместит каждое число `num` на индекс `num - 1` без доп. памяти

---

## 📚 Table of Patterns / Таблица паттернов

| №   | Pattern / Шаблон            | Condition / Условие                               | LeetCode Example / Примеры задач       |
| --- | --------------------------- | ------------------------------------------------- | -------------------------------------- |
| 1️⃣ | 📌 Place `i+1` at index `i` | Elements `1..n`, no duplicates                    | `268. Missing Number` (with mod)       |
| 2️⃣ | 🧩 Find all duplicates      | Elements `1..n`, some values appear twice         | `442. Find All Duplicates in an Array` |
| 3️⃣ | 🔁 Sort by value as index   | Goal: `nums[i] == i + 1` (first missing positive) | `41. First Missing Positive`           |
| 4️⃣ | 🎯 Detect misplaced numbers | Goal: values missing from proper indices          | `448. Find All Numbers Disappeared`    |
| 5️⃣ | 🛠 Swap until correct       | While loop + swap till value is in place          | `645. Set Mismatch`, `287. Duplicate`  |

---

## 🧠 Why is Cyclic Sort Optimal?

| Reason (EN)                                | Обоснование (RU)                                |
| ------------------------------------------ | ----------------------------------------------- |
| Avoids extra space                         | Не требует доп. памяти (in-place)               |
| Each value is moved at most once           | Каждое значение перемещается максимум 1 раз     |
| Early break possible if correct            | Возможен ранний выход, если всё на своих местах |
| Excellent for `O(n)` + `O(1)` requirements | Подходит для `O(n)` задач с `O(1)` по памяти    |

---

## 🧪 Where Cyclic Sort Fails (Где НЕ применять)

| ❌ Condition                            | 🚫 Почему не сработает                        |
| -------------------------------------- | --------------------------------------------- |
| Elements out of range (`< 0`, `> n`)   | Нельзя использовать индексную логику          |
| Duplicates + strict placement required | Нужно учитывать конфликт при swap             |
| Value-to-index mapping not meaningful  | Не каждый `num` имеет "место" `num - 1`       |
| Requires stable sorting                | Этот метод **не стабилен** (нарушает порядок) |

---

## 🧠 Visual Intuition

**Пример (на русском):**

```csharp
nums = [3, 4, -1, 1]

Идея: если nums[i] = x, и x ∈ [1..n], то поставить x на позицию x-1
После сортировки по шаблону: [1, -1, 3, 4]
→ Первый i, где nums[i] != i + 1 → это ответ (i+1 = 2)
```

---
