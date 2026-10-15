/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int SumNumbers(TreeNode root) {
        int tt = 0;
        string rootValue = $"{root.val}";
        if(root.left != null)
            runSum(root.left, rootValue, ref tt);
        if(root.right != null)
            runSum(root.right, rootValue, ref tt);
        if(root.left == null && root.right == null)
            AddNodeValue(rootValue, ref tt);
        return tt;
    }

    private void runSum(TreeNode node, string valBranch, ref int tt){
        string nodeValue = valBranch + ',' + node.val;
        if(node.left != null)
            runSum(node.left, nodeValue, ref tt);
        if(node.right != null)
            runSum(node.right, nodeValue, ref tt);
        if(node.left == null && node.right == null)
            AddNodeValue(nodeValue, ref tt);
    }
    private void AddNodeValue(string valBranch, ref int tt){
        int[] num = Array.ConvertAll(valBranch.Split(','), int.Parse);
        for(int i = num.Length-1; i >= 0; i--)
            tt += num[i]*(int)Math.Pow(10, num.Length-1-i);
    }
}