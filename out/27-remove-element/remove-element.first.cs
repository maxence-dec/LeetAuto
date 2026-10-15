public class Solution {
    public int RemoveElement(int[] nums, int val) {
        if(nums.Length==0)
            return 0;
        else if(nums.Length==1)
            return nums[0]==val?0:1;

        int idx = nums.Length-1;
        int k = 0;
        while(idx >= 0)
        {
            if(nums[idx] == val){
                k++;
                nums[idx] = nums[nums.Length-k];
            }
            idx--;
        }
        return nums.Length-k;
    }
}