public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        int result = 0;
        var comparer = Comparer<int>.Create((a, b) => {
            return b - a;
        });
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(comparer);
        foreach(int i in nums)
            pq.Enqueue(i , i);
        while(k != 0) {
            result = pq.Dequeue();
            k--;
        }
        return result;
    }
}