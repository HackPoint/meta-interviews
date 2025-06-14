Perfect. Here's your **Binary Tree Traversal Cheatsheet**, custom-tailored for interview prep and your 9-day sprint.

---

# 🧠 Binary Tree Traversal Cheatsheet (Interview-Focused)

---

## 🔺 1. Pre-order Traversal

**Order:** `Root → Left → Right`
**Use Cases:**

* Flatten binary tree
* Copy tree
* Serialize/deserialize (prefix form)

**Recursive Pattern:**

```csharp
void Traverse(TreeNode node) {
  if (node == null) return;
  visit(node);                  // Root
  Traverse(node.left);         // Left
  Traverse(node.right);        // Right
}
```

**Iterative (with stack):**

* Push root → while stack not empty:

    * Pop, visit
    * Push right then left

---

## 🔻 2. Post-order Traversal

**Order:** `Left → Right → Root`
**Use Cases:**

* Delete/free tree nodes
* Bottom-up calculations (e.g., diameter)
* Evaluate expressions (parse trees)

**Recursive Pattern:**

```csharp
void Traverse(TreeNode node) {
  if (node == null) return;
  Traverse(node.left);         // Left
  Traverse(node.right);        // Right
  visit(node);                 // Root
}
```

**Iterative (harder, reverse of pre-order with two stacks or reversed list)**

---

## 🔹 3. In-order Traversal

**Order:** `Left → Root → Right`
**Use Cases:**

* Validate BST
* Convert BST to sorted list
* Kth smallest in BST

**Recursive Pattern:**

```csharp
void Traverse(TreeNode node) {
  if (node == null) return;
  Traverse(node.left);         // Left
  visit(node);                 // Root
  Traverse(node.right);        // Right
}
```

**Iterative (with stack):**

* Go left until null → pop → visit → go right

---

## 🌐 4. Level-order Traversal (Breadth First Search)

**Order:** Level by level, left to right
**Use Cases:**

* Find min depth / max width
* Zigzag/spiral traversal
* Vertical order / bottom view

**Pattern:**

```csharp
Queue<TreeNode> queue = new();
queue.Enqueue(root);

while (queue.Count > 0) {
  var node = queue.Dequeue();
  visit(node);
  if (node.left != null) queue.Enqueue(node.left);
  if (node.right != null) queue.Enqueue(node.right);
}
```

---

## 🧩 5. Reverse Pre/Post-order (used in flattening)

**Reverse Post-order (Right → Left → Root)** is used in:

* In-place flattening to linked list
* Top-down memory-efficient rewiring

---

## 🛠 Common Problems per Traversal

| Problem                    | Type           | Link         |
|----------------------------|----------------|--------------|
| Flatten Binary Tree        | Pre-order      | LeetCode 114 |
| Validate BST               | In-order       | LeetCode 98  |
| Lowest Common Ancestor     | Post-order     | LeetCode 236 |
| Level Order Traversal      | Level-order    | LeetCode 102 |
| Diameter of Tree           | Post-order     | LeetCode 543 |
| Kth Smallest in BST        | In-order       | LeetCode 230 |
| Serialize/Deserialize Tree | Pre/Post-order | LeetCode 297 |

---

## 📌 Tips to Memorize

* **Pre-order:** Think **"visit → children"**
* **In-order:** Think **"sorted BST"**
* **Post-order:** Think **"solve subproblems first"**
* **Level-order:** Think **"queue-based BFS"**

---

