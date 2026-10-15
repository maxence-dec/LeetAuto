public class Solution {
    public int LastStoneWeight(int[] stones) {
        var pq = new PriorityQueue<int, int>();
        foreach (var stone in stones)
            //1000 max value from priority to inverse priority
            pq.Enqueue(stone, 1000-stone);
        while (pq.Count > 1){
            pq.TryDequeue(out int x, out int _);
            pq.TryDequeue(out int y, out int _);
            if (x != y)
                pq.Enqueue(Math.Abs(x-y), 1000-Math.Abs(x-y));
        }
        int result = 0;
        if(pq.Count == 1)
            pq.TryDequeue(out result, out int _);
        return result;
    }
}