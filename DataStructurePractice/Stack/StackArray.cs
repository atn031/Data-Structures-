using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Anh Nguyen 
 * Class Name: Queue
 * Description: Read and watched concepts about a Stack without seeing any code. 
 * I proceeded to code a representation of a Queue using an Array from said concepts. 
 */
namespace StackPractice
{
    class StackArray<T>
    {
        public int Index { get; private set; }
        public int Top { get; private set; }
        public int NumElements { get; private set; }
        public T[] Stack { get; private set; }

        public StackArray()
        {
            NumElements = 0;
            Index = 0;
            Top = -1;
            Stack = new T[5];
        }

        //pushes an element onto the stack 
        public void push(T toInsert)
        {
            //Case 1: Stack has has space for a new element to be inserted
            if(NumElements < Stack.Length)
            {
                Stack[Index] = toInsert;
            }

            //Case 2: Stack is currently full
            else 
            {

                T[] newStack = new T[Stack.Length + 5];
                int position = 0;

                foreach(T element in Stack)
                {
                    newStack[position] = element;
                    position++;
                
                }
                Stack = newStack;
                Stack[Index] = toInsert;
            }

            Index++;
            NumElements++;
            Top++;
        }

        //removes and returns the top element of the stack. An empty stack exception is thrown if the stack is empty and pop is called.
        public T pop()
        {
            if (NumElements == 0)
                throw new ArgumentNullException("List is empty nothing to pop");
            else
            {
                T pop = Stack[Top];
                Stack[Top] = default(T);
                Index--;
                Top--;
                NumElements--;
                return pop;
            }
        }

        //returns the element at the top of stack but does not remove it.
        public T peek()
        {
            return Stack[Top];
        }

        //returns true if stacck is empty, else return false
        public Boolean isEmpty()
        {
            return NumElements == 0;
        }

        //returns position of the node that contains the element
        public int search(T element)
        {
            int position = 0;
            Boolean found = false;
            foreach(T aElement in Stack)
            {
                if (aElement.Equals(element))
                {
                    found = true;
                    break;
                }
                else
                    position++;
            }

            if (found == true)
                return position;
            else
                return -1;

        }


    }
}

