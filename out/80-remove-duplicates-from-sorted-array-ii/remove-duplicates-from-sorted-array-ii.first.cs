public class Solution {
    private static void Collapse(int[] nums, int idx){
        for(int i = idx; i < nums.Length-1; i++)
            nums[i] = nums[i+1];
    }

    public int RemoveDuplicates(int[] nums) {
        if(nums.Length == 1)
            return 1;
        int k = 1;
        for(int i = nums.Length-1; i > 1; i--)
        {
            if(nums[i] == nums[i-1] && i >= 2 && nums[i] == nums[i-2])
            {
                Collapse(nums, i);
                continue;
            }
            k++;
        }
        return k+1;
    }
}