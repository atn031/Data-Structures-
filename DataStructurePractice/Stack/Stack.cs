using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListPractice;

/*
 * Anh Nguyen 
 * Class Name: Stack
 * Description: Read and watched concepts about a Queue without seeing any code. 
 * I proceeded to code a representation of a Stack from said concepts. 
 */
namespace StackPractice
{
    public class Stack<T>
    {
        //represents the top of the stack
        public Node<T> top;

        //pushes an element to the top of the stack
        public void push(T toInsert)
        {
            Node<T> toAdd = new Node<T>(toInsert);

            //Case 1: Stack is empty
            if (top == null)
                top = toAdd;
            //Case 2: Stack is not empty
            else
            {
                //new element becomes the top of the list
                toAdd.Next = top;
                top = toAdd;
            }
        }

        //removes and returns the top element of the stack. An empty stack exception is thrown if the stack is empty and pop is called.
        public Node<T> pop()
        {
            //Case 1: Stack is empty, user should not be able to remove from empty Stack
            if (top == null)
                throw new NullReferenceException("The stack doesn't have any elements");
            //Case 2: Stack contains at least 1 element
            else 
            {
                Node<T> toPop = top;
                top = top.Next;
                return toPop;
            }

        }

        //returns the element at the top of stack but does not remove it.
        public Node<T> peek()
        {
            if (top == null)
                throw new NullReferenceException("The stack doesn't have any elements");
            else
                return top;

        }

        //returns true if stack is empty, else return false
        public Boolean isEmpty()
        {
            return (top == null);
        }

        //searchs the stack to see the given element exist.
        public Boolean search(T element)
        {
            if (top == null)
                return false;

            else
            {
                Node<T> traverse = top;
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
