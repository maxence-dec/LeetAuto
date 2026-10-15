public class Solution {
    public int Jump(int[] nums) {
        return jumpFrom(nums, nums.Length-1);
    }

    private int jumpFrom(int[] nums, int k){
        Console.Write($"{k}\n");
        if(k == 0)
            return 0;
        int jumps = nums.Length;
        for(int i = 0; i <k ; i++){
            if(i + nums[i] >= k){
                jumps = jumpFrom(nums, i);
                break;
            }
        }
        return jumps+1;
    }
}