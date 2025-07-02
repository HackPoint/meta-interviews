namespace Leetcode.Easy.Arrays;

public class MinimumCostToMoveChipsInTheSamePosition
{
    public int MinCostToMoveChips(int[] position) {
        int oddCount = 0;
        int evenCount = 0;

        for(int i = 0; i < position.Length; i++) {
            int pos = position[i];
            if(pos % 2 == 0) 
                evenCount++;
            else
                oddCount++;    
        }

        return System.Math.Min(oddCount, evenCount);
    }
}