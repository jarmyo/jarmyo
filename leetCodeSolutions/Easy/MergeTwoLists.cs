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
            //this code results:
            //Runtime: 109 ms
            //Memory Usage: 38 MB

            if (l1 == null) return l2; //Optimization if one of the list is empty
            if (l2 == null) return l1;
            ListNode result = new();
            var node = result; //create a pointer of the first element.            
            System.Collections.Generic.List<int> values = new(); //Create a list to store the ordered numbers

            //Fill with the first list
            while (l1 != null) 
            {
                values.Add(l1.val);
                l1 = l1.next;
            }

            while (l2 != null) //now, iterate the second list node
            {
                int index = 0; // create a iterator index
                while (index < values.Count) //of the ordered values list
                {
                    if (l2.val <= values[index])
                        break; //iterate the list until the item is bigger
                    index++;
                }
                values.Insert(index, l2.val); //insert in that position the new number
                l2 = l2.next;
            }

            for (int i = 0; i < values.Count; i++) //now we have a list with ordered values of the two list nodes
            {
                result.val = values[i]; //insert the value in the node
                if (i < values.Count - 1) //create a next node until the one before last item.
                {
                    result.next = new ListNode();
                    result = result.next;
                }
            }
            return node; //return the pointer of first element of result.
        }
        public static (ListNode, ListNode) MergeTwoLists_TestCase()
        {
            var test = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(4)
                }
            };
            var test2 = new ListNode(1)
            {
                next = new ListNode(3)
                {
                    next = new ListNode(4)
                }
            };
            return (test, test2);
        }
    }
}