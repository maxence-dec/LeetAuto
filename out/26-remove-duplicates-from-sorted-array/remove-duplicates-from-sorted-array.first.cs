public class Solution {
    public int RemoveDuplicates(int[] nums) {
        Dictionary<int,bool> intExists = new();
        int k = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(!intExists.ContainsKey(nums[i]))
            {
                intExists[nums[i]] = true;
                nums[k] = nums[i];
                k++;
            }
        }
        return k;
    }
}