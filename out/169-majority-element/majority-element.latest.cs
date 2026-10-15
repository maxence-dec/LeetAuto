public class Solution {
    public int MajorityElement(int[] nums) {
        int Majority = 0;
        int Count = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(Count == 0)
                Majority = nums[i];

            if(nums[i] == Majority)
                Count++;
            else
                Count--;
        }
        return Majority;
    }
}