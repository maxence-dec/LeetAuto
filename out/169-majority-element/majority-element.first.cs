public class Solution {
    public int MajorityElement(int[] nums) {
        Dictionary<int, int> valueCount = new();
        foreach(int i in nums){
            if(valueCount.ContainsKey(i)){
                valueCount[i]++;
                if(valueCount[i] >= nums.Length/2+1)
                    return i;
            }
            else
                valueCount[i] = 1;
        } 
        return nums[0];
    }
}