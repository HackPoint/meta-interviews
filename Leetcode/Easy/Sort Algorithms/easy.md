Отлично. Начнём с полного списка основных сортировок, их шаблонов (code templates), а затем я сгенерирую 3 задачи для каждой из них.

---

### 🔢 Основные алгоритмы сортировки

| 🧠 Алгоритм    | 📦 Сложность (Time) | 🔁 Шаблон (на англ.)    | 💬 Применение                             |
| -------------- | ------------------- | ----------------------- | ----------------------------------------- |
| Bubble Sort    | O(n²)               | Classic nested loop     | Простая, учебная                          |
| Selection Sort | O(n²)               | Select min and swap     | Учебная, сортирует по выбору              |
| Insertion Sort | O(n²)               | Shift until position    | Почти отсортированные массивы             |
| Merge Sort     | O(n log n)          | Divide & conquer        | Стабильная, рекурсивная                   |
| Quick Sort     | O(n log n) avg      | Partitioning            | Быстрая, но нестабильная                  |
| Heap Sort      | O(n log n)          | Build heap & extract    | Не требует рекурсии                       |
| Counting Sort  | O(n + k)            | Count occurrences       | Только для чисел в ограниченном диапазоне |
| Radix Sort     | O(nk)               | Digit by digit          | Для чисел, строк с фиксированной длиной   |
| Bucket Sort    | O(n + k)            | Distribute into buckets | Для равномерных данных                    |
| Shell Sort     | \~O(n^1.5)          | Gapped insertion        | Улучшение insertion sort                  |

---

## ✅ Code Templates

### 1. Bubble Sort

```csharp
void BubbleSort(int[] arr) {
    int n = arr.Length;
    for (int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
        }
    }
}
```

### 2. Selection Sort

```csharp
void SelectionSort(int[] arr) {
    int n = arr.Length;
    for (int i = 0; i < n - 1; i++) {
        int minIdx = i;
        for (int j = i + 1; j < n; j++) {
            if (arr[j] < arr[minIdx])
                minIdx = j;
        }
        (arr[i], arr[minIdx]) = (arr[minIdx], arr[i]);
    }
}
```

### 3. Insertion Sort

```csharp
void InsertionSort(int[] arr) {
    for (int i = 1; i < arr.Length; i++) {
        int key = arr[i], j = i - 1;
        while (j >= 0 && arr[j] > key) {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = key;
    }
}
```

### Merge Sort
```csharp
void MergeSort(int[] arr, int left, int right) {
    if (left >= right) return;
    int mid = (left + right) / 2;
    MergeSort(arr, left, mid);
    MergeSort(arr, mid + 1, right);
    Merge(arr, left, mid, right);
}
```

### Quick Sort
```csharp
void QuickSort(int[] arr, int low, int high) {
    if (low < high) {
        int pi = Partition(arr, low, high);
        QuickSort(arr, low, pi - 1);
        QuickSort(arr, pi + 1, high);
    }
}
```

### Counting Sort
```csharp
int[] CountSort(int[] arr) {
    int max = arr.Max();
    int[] count = new int[max + 1];
    foreach (int num in arr) count[num]++;
    int index = 0;
    for (int i = 0; i <= max; i++) {
        while (count[i]-- > 0) arr[index++] = i;
    }
    return arr;
}

```

### Radix Sort (LSD)
```csharp
void RadixSort(int[] arr) {
    int max = arr.Max(), exp = 1;
    while (max / exp > 0) {
        CountingSortByDigit(arr, exp);
        exp *= 10;
    }
}
```

### Bucket Sort
```csharp
List<int>[] buckets = new List<int>[bucketCount];
foreach (int val in arr) {
    int idx = val * bucketCount / (maxValue + 1);
    buckets[idx].Add(val);
}
foreach (var bucket in buckets) bucket.Sort();

```

### Heap Sort

```csharp
void HeapSort(int[] arr) {
    int n = arr.Length;
    for (int i = n / 2 - 1; i >= 0; i--) Heapify(arr, n, i);
    for (int i = n - 1; i > 0; i--) {
        (arr[0], arr[i]) = (arr[i], arr[0]);
        Heapify(arr, i, 0);
    }
}
```
###  Shell Sort

```csharp
void ShellSort(int[] arr) {
    int n = arr.Length;

    // Начинаем с большого интервала, делим его на 2
    for (int gap = n / 2; gap > 0; gap /= 2) {
        // Применяем сортировку вставкой для подмассивов с текущим gap
        for (int i = gap; i < n; i++) {
            int temp = arr[i];
            int j = i;

            // Сдвигаем элементы, пока не найдём правильную позицию для temp
            while (j >= gap && arr[j - gap] > temp) {
                arr[j] = arr[j - gap];
                j -= gap;
            }

            arr[j] = temp;
        }
    }
}
```
