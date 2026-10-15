/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int val = l1.val+l2.val;
        return new ListNode(val%10, AddTwoNumbers(l1.next, l2.next,val/10));
    }

    private ListNode AddTwoNumbers(ListNode? l1, ListNode? l2, int i = 0){
        if(l1 == null && l2 == null && i == 0)
            return null;
        int val = (l1?.val??0) + (l2?.val??0) + i;
        return new ListNode(val%10, AddTwoNumbers(l1?.next, l2?.next, val/10));
    }
}