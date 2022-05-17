/*
    LeetCode: 230. Kth Smallest Element in a BST
    https://leetcode.com/problems/kth-smallest-element-in-a-bst/

    NeetCode Solution:
    Uses recursive traversal of tree.
    https://www.youtube.com/watch?v=5LUXSvjmGCw

    First:
        I thought of only traversing a left-skwed tree result should contain a the Kth element.
        This is a wrong assumption. Second or third smallest element can be found in the right subtree 3ady y3ny.
        Think of a BST of only a left child and the remaining elements at the right subtree.
    Second:
        Solution key is to think of inorder traversal because it results in an ordered list of BST.
*/

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

/*
    Naive Approach: Inorder traversal yields an ordered list of the BST,
    So make a list, and the k - 1 element of the list is the Kth smallest element.
*/
 public class Solution_MyVeryFirstOne {
    public int KthSmallest(TreeNode root, int k) 
    {
        if(root == null)    return 0;
        
        List<int> inOrderList = new List<int>();
        
        InOrderTraversal(root, inOrderList);
        
        return inOrderList[k - 1];
    }
    // Here I expose my knowledge of void in-order traversal only.
    private void InOrderTraversal(TreeNode node, List<int> list)
    {
        if(node == null)    return;
        
        InOrderTraversal(node.left, list);
        list.Add(node.val);
        InOrderTraversal(node.right, list);
    }
}

/* 
    Uses a private field, and I turned it into int ref istead.
    1 - It visits the left subtree until exaughsted (totally consumed)
    2 - decrement the counter
    3 - If counter 0 (Kth  found), then return the current node. (it should be popped from the call stack)
    4 - If counter is not 0 (Kth still not found), then traverse the right subtree.
 */
public class Solution_84ms {
    // But gave me 125 ms as best submission for me.
    public int KthSmallest(TreeNode root, int k) {
        int count = k;
        TreeNode kthNode = InOrderTraversal(root, ref count);
        return  kthNode.val;
    }
    
    /* New for me: In-order traversal with return.
        Previously, I knew void traversal.
     */
    private TreeNode InOrderTraversal(TreeNode node, ref int count)
    {
        if(node == null)    return null;
        
        TreeNode left = InOrderTraversal(node.left, ref count);
        if(left != null)   return left;
        
        count--;
        if(count == 0)  return node;
        
        TreeNode right = InOrderTraversal(node.right, ref count);
        return right;
    }
}