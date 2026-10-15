public class Solution {
    public void Rotate(int[] nums, int k) {
        //if k > nums.Length/2 changer de sens?
        if(nums.Length < 2 || k == nums.Length || k < 1)
            return;
        k = k%nums.Length;
        int[] temps = new int[k];
        for(int i = 0; i < k; i++)
            temps[i] = nums[nums.Length-k+i];
        for(int i = 0; i < nums.Length; i++){
            int temp = nums[i];
            nums[i] = temps[i%k];
            temps[i%k] = temp;
        }
    }
}