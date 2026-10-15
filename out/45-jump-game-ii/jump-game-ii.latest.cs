public class Solution {
    public int Jump(int[] nums) {
        int jumps = 0, farthest = 0, end = 0;
        
        for (int i = 0; i < nums.Length - 1; i++) {
            // Update the farthest point we can reach
            farthest = Math.Max(farthest, i + nums[i]);
            
            // If we've reached the current end, we need to jump
            if (i == end) {
                jumps++;
                end = farthest; // Update the range for the next jump
            }
        }
        
        return jumps;
    }
}