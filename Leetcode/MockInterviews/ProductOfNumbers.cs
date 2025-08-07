namespace Leetcode.MockInterviews;

public class ProductOfNumbers {
    private readonly List<int> prefixes = new();
    public ProductOfNumbers() {
        prefixes.Add(1);
    }
    
    public void Add(int num) {
        if(num == 0) {
            prefixes.Clear();
            prefixes.Add(1);
        } else {
            int lastPrefix = prefixes[^1];
            prefixes.Add(lastPrefix * num);
        }
    }
    
    public int GetProduct(int k) {
        if(k >= prefixes.Count) return 0;
        return prefixes[^1] / prefixes[prefixes.Count - 1 - k];
    }
}