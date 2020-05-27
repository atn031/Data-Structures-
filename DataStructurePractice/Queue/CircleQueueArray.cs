using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Anh Nguyen 
 * Class Name: Queue
 * Description: Read and watched concepts about a Queue without seeing any code. 
 * I proceeded to code a representation of a Queue using an array. For extra practice I implemented a circular array.
 */
namespace QueuePractice
{ 
    class CircleQueueArray<T>
    {
        public int NumberElements { get; private set; }
        public T[] TheQueue { get; private set; }
        public int Front { get; private set; }
        public int Index { get; private set; }

        //Initialize the generic array with a default capacity of 5
        public CircleQueueArray()
        {
            NumberElements = 0;
            TheQueue = new T[5];
            Front = 0;
            Index = 0;
        }

        //pushes an element to the top of the stack
        public void add(T toInsert)
        {
            //first case: There is available space in the Queue for a new element
            if (NumberElements <= TheQueue.Length-1)
            {
                //The index is no longer pointing to a valid index in the array, set it back to first index in the array
                if(Index > TheQueue.Length - 1)
                {
                    Index = 0;
                }
                TheQueue[Index] = toInsert;
                
            }
            //second case: The queue has no space to add the new element.
            else
            {
                //Create a new array with additional space of 5
                T[] newQueue = new T[TheQueue.Length + 5];
                int position = 0;
                
                //Copy all existing data in current array to newly created array
                foreach (T element in TheQueue)
                {
                    newQueue[position] = element;
                    position++;
                }

                TheQueue = newQueue;
                TheQueue[Index] = toInsert;
            }

            Index++;
            NumberElements++;
        }

        //removes and returns the first element in queue, if the list is empty. return exception list is empty.
        public T dequeue()
        {
            if (NumberElements == 0)
                throw new IndexOutOfRangeException("LIST IS EMPTY");
            else
            {

                T firstValue = TheQueue[Front];
                TheQueue[Front] = default(T);
                NumberElements--;
                if (NumberElements > 0)
                    Front++;
                else
                    Index--; //if the list is empty an index isn't changed, Index will be 1 greater than Front. 

                if (Front > TheQueue.Length - 1)
                    Front = 0;

                return firstValue;
            }
        }

        //returns the element at the front of the Queue but does not remove it.
        public T peek()
        {
            return TheQueue[Front];
        }

        //returns true if queue is empty, else return false
        public Boolean isEmpty()
        {
            return NumberElements == 0;
        }

        //returns the current position of the element in the Queue. 
        public int search(T element)
        {
            int position = 0;
            Boolean found = false;
            foreach (T aElement in TheQueue)
            {
                if (aElement.Equals(element))
                {
                    found = true;
                }
                else
                    position++;
            }

            if (found == true)
                return position;
            else
                return -1;
        }

        //print the Queue
        public void printQueue()
        {
            Console.Write("The elements in the queue are:");
            foreach(T element in TheQueue)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
    }
}
