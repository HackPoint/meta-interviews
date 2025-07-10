using System.Text;
using Leetcode.Easy.LinkedList.DFS;

namespace Leetcode.Hard.BT;

/// <summary>
/// ✅ Classification: Tree Traversal / DFS  
/// ✅ Algorithm: Recursive Pre-order DFS serialization with “null,” markers; queue-based deserialization  
///
/// ✅ Explanation (RU):  
/// • <b>serialize</b> — выполняет рекурсивный обход <i>pre-order</i>.  
///   – Если узел = null → добавляем строку <c>"null,"</c>.  
///   – Иначе пишем <c>val,</c>, затем рекурсивно левое и правое поддерево.  
/// • <b>deserialize</b> — разбивает строку по запятой, формирует очередь токенов,  
///   после чего восстанавливает дерево тем же порядком (root-left-right),  
///   извлекая токены из очереди в рекурсивном методе <c>Build</c>.  
///
/// ✅ Time Complexity:  
/// • serialize   O(n) — посещаем каждый узел один раз  
/// • deserialize O(n) — читаем каждый токен один раз  
///
/// ✅ Space Complexity:  
/// • serialize   O(h)  стек вызовов + O(n) длина результирующей строки  
/// • deserialize O(h)  стек вызовов + O(n) очередь токенов  
///
/// ▸ Преимущества: простота, читаемость, однозначное восстановление структуры.  
/// ▸ Ограничения: <c>string.Split</c> и <c>Queue</c> порождают O(n) аллокаций;  
///   при очень больших деревьях есть риск переполнения стека из-за глубокой рекурсии.
/// </summary>

public class Codec {
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        StringBuilder serializable = new();
        Dfs(root, serializable);
        return serializable.ToString();
    }

    private void Dfs(TreeNode node, StringBuilder serializable) {
        if (node == null) {
            serializable.Append("null,");
            return;
        }
        serializable.Append(node.val).Append(',');

        Dfs(node.left, serializable);
        Dfs(node.right, serializable);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        var queue = new Queue<string>(data.Split(",", StringSplitOptions.RemoveEmptyEntries));
        return Build(queue);
    }

    private TreeNode Build(Queue<string> queue) {
        string val = queue.Dequeue();
        if(val == "null") return null;

        TreeNode node = new(int.Parse(val));
        node.left = Build(queue);
        node.right = Build(queue);

        return node;
    }
}