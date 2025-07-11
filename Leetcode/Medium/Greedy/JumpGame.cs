namespace Leetcode.Medium.Greedy;

/// <summary>
/// ✅ Classification: Greedy (Array Traversal)
/// ✅ Algorithm: Single Pass, Max Reach Tracking
///
/// ✅ Explanation (RU):
/// Поддерживаем переменную <b>maxReach</b> — самый дальний индекс,
/// до которого мы можем допрыгнуть на текущем шаге.
///   • Идём по массиву слева направо.<br/>
///   • Если текущий индекс <c>i</c> превышает <c>maxReach</c>,
///     позиция недостижима ⇒ сразу <c>false</c>.<br/>
///   • Иначе обновляем: <c>maxReach = max(maxReach, i + nums[i])</c>.<br/>
///   • Как только <c>maxReach</c> ≥ последний индекс, возвращаем <c>true</c>.
///
/// ✅ Time Complexity:  O(n)  – один линейный проход.
/// ✅ Space Complexity: O(1)  – константная память (только два int).
/// </summary>
public class JumpGame
{
    public bool CanJump(int[] nums) {
        int maxReach = 0;
        for(int i = 0; i < nums.Length; i++) {
            if(i > maxReach) return false;
            maxReach = Math.Max(maxReach, i + nums[i]);

            if(maxReach >= nums.Length - 1) 
                return true;
        }

        return maxReach >= nums.Length - 1;
    }
}