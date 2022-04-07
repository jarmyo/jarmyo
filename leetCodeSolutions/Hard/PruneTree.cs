namespace leetCodeSolutions.Hard
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/explore/featured/card/july-leetcoding-challenge-2021/611/week-4-july-22nd-july-28th/3824
        /// <br/>Given the root of a binary tree, return the same tree where every subtree (of the given tree) not containing a 1 has been removed.
        /// A subtree of a node node is node plus every node that is a descendant of node.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode PruneTree(TreeNode root)
        {
            //no sé nada de arboles binarios, pero confio en mi y vamos a resolver esto.
            //recursividad?
            if (root.left != null)
            {
                root.left = PruneTree(root.left);
            }
            if (root.right != null)
            {
                root.right = PruneTree(root.right);
            }

            if (root.left == null && root.right == null)
            {
                if (root.val == 1)
                    return root;
                else
                    return null;
            }
            else
            {
                return root;
            }
        }
    }
}
