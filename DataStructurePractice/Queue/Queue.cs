using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListPractice;


/*
 * Anh Nguyen 
 * Class Name: Queue
 * Description: Read and watched concepts about a Queue without seeing any code. 
 * I proceeded to code a representation of a Queue from said concepts. 
 */
namespace QueuePractice
{
    public class Queue<T>
    {
        //represents the number of elements in the Queue
        public int Size { get; set; }
        //points to the first Node in the Queue
        Node<T> head;

        //used to add elements at the tail of queue
        public void Enqueue(T elementToAdd)
        {
            Node<T> toAdd = new Node<T>(elementToAdd);
            Size++;

            if (head == null)
                head = toAdd;
            else 
            {
                Node<T> goToEnd = head;
                while(goToEnd.Next != null)
                {
                    goToEnd = goToEnd.Next;
                }
                goToEnd.Next = toAdd;
            }
        }

        //view head of the queue without removing it, returns null if empty
        public Node<T> peek()
        {
            if (head == null)
                throw new NullReferenceException("The queue is empty");
            else
                return head;

        }

        //removes and returns the head of the queue/ throws NoSuchElementionException when queue is empty
        public Node<T> Dequeue()
        {
            if (head == null)
                throw new NullReferenceException("The queue is empty");
            else
            {
                Node<T> toRemove = head;
                head = head.Next;
                Size--;
                return toRemove;
            }
        }

        //Checks to to see if the queue is empty
        public Boolean isEmpty()
        {
            return (Size == 0);
        }

        //Seach queue to see if an element exist within it.
        public Boolean getNodeWithElement(T element)
        {
            //Case 1: element wont exist because Queue is empty
            if (head == null)
                return false;

            //Case 2: element may exist, and queue is not empty 
            else
            {
                Node<T> traverse = head;
                Boolean found = false;
                while (traverse != null && found == false)
                {
                    if (traverse.Value.Equals(element))
                    {
                        return true;
                    }
                    traverse = traverse.Next;
                }
                return false;
            }
        }

    }
}
