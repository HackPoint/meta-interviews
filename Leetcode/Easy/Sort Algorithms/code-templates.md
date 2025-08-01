Отлично. Начнём с полного списка классических сортировок, их шаблонов и далее перейдём к тренировочным задачам.

---

### 📦 Основные Алгоритмы Сортировки + Шаблоны

| 🔢 Название        | 💡 Сложность | 📋 Описание                                     |
| ------------------ | ------------ | ----------------------------------------------- |
| **Bubble Sort**    | O(n²)        | Попарный обмен до отсортированности             |
| **Selection Sort** | O(n²)        | Выбор наименьшего и его перемещение             |
| **Insertion Sort** | O(n²)        | Вставка каждого элемента в отсорт. часть        |
| **Merge Sort**     | O(n log n)   | Разделение массива и слияние отсортированных    |
| **Quick Sort**     | O(n log n)   | Разделение по опорному и рекурсия               |
| **Heap Sort**      | O(n log n)   | Построение кучи и извлечение макс/мин           |
| **Counting Sort**  | O(n + k)     | Подсчёт частот (только для int, малый диапазон) |
| **Radix Sort**     | O(nk)        | Поразрядная сортировка чисел                    |
| **Bucket Sort**    | O(n + k)     | Деление на ведра, сортировка внутри             |

---

### 📋 Code Templates (C#-style псевдокод)

#### 🔁 Bubble Sort

```csharp
for (int i = 0; i < n - 1; i++)
    for (int j = 0; j < n - i - 1; j++)
        if (arr[j] > arr[j + 1])
            Swap(arr[j], arr[j + 1]);
```

#### ✅ Selection Sort

```csharp
for (int i = 0; i < n - 1; i++) {
    int minIdx = i;
    for (int j = i + 1; j < n; j++)
        if (arr[j] < arr[minIdx])
            minIdx = j;
    Swap(arr[i], arr[minIdx]);
}
```

#### 📝 Insertion Sort

```csharp
for (int i = 1; i < n; i++) {
    int key = arr[i], j = i - 1;
    while (j >= 0 && arr[j] > key)
        arr[j + 1] = arr[j--];
    arr[j + 1] = key;
}
```

#### 🔀 Merge Sort

```csharp
void MergeSort(int[] arr, int left, int right) {
    if (left >= right) return;
    int mid = (left + right) / 2;
    MergeSort(arr, left, mid);
    MergeSort(arr, mid + 1, right);
    Merge(arr, left, mid, right);
}
```

#### ⚡ Quick Sort

```csharp
void QuickSort(int[] arr, int low, int high) {
    if (low >= high) return;
    int pivot = Partition(arr, low, high);
    QuickSort(arr, low, pivot - 1);
    QuickSort(arr, pivot + 1, high);
}
```

#### 🛠️ Heap Sort

```csharp
BuildMaxHeap(arr);
for (int i = n - 1; i >= 0; i--) {
    Swap(arr[0], arr[i]);
    Heapify(arr, 0, i);
}
```

#### 📊 Counting Sort

```csharp
int[] count = new int[max + 1];
foreach (int x in arr) count[x]++;
// потом накопление и построение результата
```


### Shell Sort
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
---

