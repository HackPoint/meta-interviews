```markdown
| 🔍 Condition / Keyword                         | 📦 Algorithm / Data Structure                    | 🧠 Explanation (RU)                                                |
|-----------------------------------------------|--------------------------------------------------|--------------------------------------------------------------------|
| "is palindrome", "can form palindrome"        | Two Pointers / Expand Around Center / Bitmask   | Симметрия строки, частота символов, проверка палиндромов          |
| "subarray", "maximum sum", "longest..."       | Sliding Window / Kadane’s Algo / Prefix Sum     | Подмассив фиксированной/переменной длины                          |
| "merge k lists", "k sorted arrays"            | Min Heap / Merge Sort                           | Используем Heap для выбора минимального из k                      |
| "median", "stream median", "Kth element"      | Heap / Binary Search                            | Два хипа или бинарный поиск по позиции                            |
| "range sum", "range update", "mutable array"  | Prefix Sum / Segment Tree / Fenwick Tree        | Префиксы — для суммы, дерево — если есть изменения                |
| "xor", "bitwise", "odd/even count"            | Bit Manipulation / Prefix XOR                   | Побитовые маски, префиксы XOR, часто при поиске уникальных чисел  |
| "longest increasing", "LIS", "non-decreasing" | DP with Binary Search / Patience Sorting        | Подпоследовательность, не обязательно подряд                      |
| "generate all", "find all combinations"       | Backtracking / DFS                              | Генерация всех возможных путей/наборов                            |
| "permutation", "arrangement"                  | Backtracking / Heap's Algorithm                 | Перестановки — полный перебор с отсечением                        |
| "subsequence", "delete to make"               | DP (LCS / Edit Distance)                        | DP на сравнение строк                                              |
| "shortest path", "minimum steps to..."        | BFS / Dijkstra / A*                             | BFS по уровням — оптимален по шагам                               |
| "can reach", "jump", "minimum moves"          | Greedy / BFS / DP                               | Проверка достижимости по массиву                                  |
| "partition", "split into k groups"            | DP + Memo / Binary Search + Predicate           | Часто решается как поиск по ответу + DP                           |
| "game", "player turn", "can win"              | Minimax + Memoization / Game Theory             | Игра с нулевой суммой → рекурсия с DP                             |
| "stock", "buy/sell", "max profit"             | DP with State Machine                           | `dp[i][k][0/1]` — день, транзакции, держим/нет                    |
| "LRU", "rate limiter", "cache design"         | HashMap + Doubly Linked List / Queue            | Часто в Design — важно O(1) операция                              |
| "startsWith", "prefix", "autocomplete"        | Trie (Prefix Tree)                              | Структура префиксных путей — часто с DFS                          |
| "find duplicate", "cycle in array/list"       | Floyd's Cycle Detection / Set                   | Fast/slow pointers + доп. память для цикла                        |
| "intervals", "merge intervals", "overlap"     | Sort + Sweep Line / Greedy                      | Сортировка по start/end и слияние                                 |
| "top K", "frequent", "least used"             | Min/Max Heap / Bucket Sort / QuickSelect        | Частота + приоритет → Heap или сортировка                        |
| "K closest", "points nearest", "most K..."    | Heap / Sort / QuickSelect                       | Часто используют max-heap на K элементов                          |
| "union", "connected", "groups"                | Union Find / DSU / Graph                        | Проверка принадлежности к компоненте                              |
| "order of tasks", "dependencies"              | Topological Sort / Kahn’s Algo / DFS            | Часто DAG → сортировка по зависимостям                            |
| "matrix island", "num of islands", "flood"    | BFS / DFS / Union Find                          | Обход 2D, подсчёт связных компонент                               |
| "minimum spanning tree", "connect all"        | Kruskal / Prim / Union Find                     | MST — граф с минимальной суммой рёбер                             |
| "satisfiability", "2-SAT", "implication"      | SCC (Kosaraju / Tarjan), Graph Coloring         | Логика → граф → компоненты сильной связности                      |
| "repeated substring", "find pattern"          | KMP / Z-Function / Rolling Hash                 | Быстрый поиск подстрок                                            |
| "decode", "ways to interpret"                 | DP + Recursion + Memo                           | Часто строки с вариантами интерпретации (1,2 = A,B...)            |
| "balanced", "valid", "parentheses"            | Stack / Greedy                                  | Баланс скобок, стек при вложенности                               |
| "monotonic", "next greater", "next smaller"   | Monotonic Stack / Deque                         | Стек с инвариантом упорядоченности                                |
| "build from preorder/inorder"                 | Tree Construction via Recursion                 | Восстановление дерева по порядку обходов                          |
| "evaluate", "expression", "calculator"        | Stack + Parser                                  | Преобразование infix/postfix, поддержка приоритетов               |
| "max area", "largest rectangle", "water trap" | Two Pointers / Stack / DP                       | Часто: вода между стенками, гистограмма                           |
| "sliding window max/min", "temperature"       | Deque (Monoqueue) / Sliding Window              | Поддержание максимумов/минимумов в окне                           |
| "serialize/deserialize", "encode/decode"      | BFS / DFS / Queue + Recursion                   | Деревья/графы → строка → дерево                                   |
| "symmetric", "same tree", "equal structure"   | DFS / Recursion                                 | Сравнение структур дерева                                         |
| "zigzag", "spiral", "level order"             | BFS / Queue / Stack                             | Зигзаговый или специфичный обход                                  |
| "build graph from input"                      | Adjacency List + Map/List                       | Преобразование данных в структуру графа                           |
| "time to infect", "min time", "burn tree"     | BFS + Level Tracking                            | BFS с подсчётом времени по уровням                                |
| "robot", "navigate", "obstacle"               | Backtracking / DFS / DP                         | Часто сетка + условия движений                                    |
| "submatrix", "sum of rectangle"               | Prefix Sum + 2D Matrix                          | Префиксные суммы в 2D, иногда с DP                                |
| "median of row-wise sorted matrix"            | Binary Search on Answer                         | Поиск ответа в отсортированном пространстве                       |
| "minimum max", "max min", "find smallest largest" | Binary Search + Predicate                     | Binary Search по ответу (Search on Answer)                        |
```

---
