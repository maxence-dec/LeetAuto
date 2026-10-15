public class Solution {
    public void Rotate(int[] nums, int k) {
        int n = nums.Length;
        k %= n;
        Reverse(nums, 0, n - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, n - 1);
    }
    private void Reverse(int[] nums, int s, int e) {
        while (e > s) {
            (nums[e], nums[s]) = (nums[s], nums[e]);
            s++;
            e--;
        }
    }
}
