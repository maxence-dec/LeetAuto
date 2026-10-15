public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int l1 = m;
        int l2 = n;

        while(l1 != 0 && l2 != 0)
        {
            if(nums1[l1-1] < nums2[l2-1])
            {
                nums1[l1+l2-1] = nums2[l2-1];
                l2--;
            }
            else
            {
                nums1[l1+l2-1] = nums1[l1-1];
                l1--;
            }
        }
        if(l1 == 0)
            for(int l = l2-1; l >= 0; l--)
                nums1[l] = nums2[l];
    }
}