using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
   public class DLList
    {
        public DLLNode head; // pointer to the head of the list
        public DLLNode tail; // pointer to the tail of the list
       public DLList() { head = null;  tail = null; } // constructor

        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */

        public void addToTail(DLLNode p)
        {

            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                /* 
                 * Original Code:
                 * tail.next = p
                 * tail = p
                 * p.previous = tail
                 * Issue:
                 * After assigning tail.next = p, the p.previous reference should be set to the previous tail, not the new tail itself. 
                 */
                p.previous = tail;
                tail.next = p;
                tail = p;
            }
        } // end of addToTail

        public void addToHead(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                head = p;
            }
        } // end of addToHead

        public void removHead()
        {
            if (this.head == null) return;


            /* 
             * Issue:
             * The removeHead method does not properly handle the case where the list has only one element. 
             * Only the head is removed, and the node pointed to by the tail no longer exists.
             */
            if (this.head == this.tail)
            {
              this.head = null;
              this.tail = null;            
              return;
            }
            this.head = this.head.next;
            this.head.previous = null;
        } // removeHead


        public void removeTail()
        {
            if (this.tail == null) return;
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
                return;
            }



        } // remove tail

        /*-------------------------------------------------
         * Return null if the string does not exist.
         * ----------------------------------------------*/
        public DLLNode search(int num)
        {

            DLLNode p = head;
            while (p != null)
            {
                /* 
                 * Original Code:
                 * p = p.next
                 * if (p.num == num) break
                 * Issue:
                 * The issue with the search method is that it's advancing p to the next node before checking if the current node's value matches the target value
                 */
                if (p.num == num) return p; 
                p = p.next;
            }
            return null; 
        } // end of search (return pionter to the node);

        public void removeNode(DLLNode p)
        { // removing the node p.
            if (p == null) return;

            // Check if p is the only node in the list
            if (this.head == p && this.tail == p)
            {
                this.head = null;
                this.tail = null;
                return;
            }

            // Check if p is the head node
            if (this.head == p)
            {
                this.head = p.next;
				this.head.previous = null;
			}
            else
            {
                // Check if p is the tail node
                if (this.tail == p)
                {
                    this.tail = p.previous;
					this.tail.next = null;
				}
                else
                {
                    // p is neither head nor tail
                    p.previous.next = p.next;
                    p.next.previous = p.previous;
                }
            }

            // Original Code:
            //if (p.next == null)
            //{
            //    this.tail = this.tail.previous;
            //    this.tail.next = null;
            //    p.previous = null;
            //    return;
            //}
            //if (p.previous == null)
            //{
            //    this.head = this.head.next;
            //    p.next = null;
            //    this.head.previous = null;
            //    return;
            //}
            //p.next.previous = p.previous;
            //p.previous.next = p.next;
            //p.next = null;
            //p.previous = null;
            //return;
            // Issue:
            // 1.When p is the last node (p.next == null), it incorrectly updates the tail reference without considering if p is also the head.
            // 2.When p is the first node (p.previous == null), it incorrectly updates the head reference without considering if p is also the tail.
            // 3.After removing p, the method unnecessarily sets p.next and p.previous to null, which is redundant since p will no longer be part of the list.

        } // end of remove a node

        public int total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                tot += p.num;
                /* 
                 * Original Code:
                 * p = p.next.next;
                 * Issue: In the total method, the loop used a step of 2, causing the method to skip every second node in the list
                 */
                p = p.next;
            }
            return (tot);
        } // end of total
    } // end of DLList class
}
