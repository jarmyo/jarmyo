namespace leetCodeSolutions
{
    public partial class Solution
    {
        /// <summary>
        ///https://leetcode.com/problems/merge-two-sorted-lists
        ///You are given the heads of two sorted linked lists list1 and list2. Merge the two lists in a one sorted list.The list should be made by splicing together the nodes of the first two lists.
        ///</summary>        
        /// <returns>Return the head of the merged linked list.</returns>
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {            
            ListNode result = new ListNode();
            var node = result;
            do
            {
                do
                {
                    if (l1.val <= l2.val)
                    {
                        result.val = l1.val;
                        result.next = new ListNode(l2.val);
                        result = result.next;
                        l1 = l1.next;
                    }
                    else
                    {
                        result.next = new ListNode();
                        result = result.next;
                        break;
                    }   
                }
                while (l2.next != null );
                l2 = l2.next;

                if (l1.next != null)
                    break;
            }
            while (true);
            return node ;
        }

        public static (ListNode,ListNode) TestCase1()
        {
            var test = new ListNode(1);
            test.next = new ListNode(2);
            test.next.next = new ListNode(4);
            var test2 = new ListNode(1);
            test2.next = new ListNode(3);
            test2.next.next = new ListNode(4);
            return (test,test2);
        }
    }
}
