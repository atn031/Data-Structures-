using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapPractice
{
    public class MaxHeap
    {
        public int[] Heap { get; set; }
        public int Capacity { get; set; }
        public int currSize { get; set; }

        //parent of Index i : index floor(i/2)
        //Left Child of node N at index i: index 2i
        //Right Child of node N at index i: index (2i+1)

        public MaxHeap(int Capacity)
        {
            Heap = new int[Capacity];
            this.Capacity = Capacity;
            currSize = 0;
            Heap[0] = 99999;
        }


        public void Insert(int newValue)
        {
            currSize++;
            Heap[currSize] = newValue;
            restoreUp(currSize);
        }

        public void restoreUp(int lastIndex)
        {
            int initialValueAtLast = Heap[lastIndex];
            int parentIndex = lastIndex / 2;

            while (Heap[parentIndex] < initialValueAtLast)
            {
                Heap[lastIndex] = Heap[parentIndex];
                lastIndex = parentIndex;
                parentIndex = lastIndex / 2;
            }

            Heap[lastIndex] = initialValueAtLast;
        }

        public void restoreUpRandomArray( int[] arrayToChange, int Index)
        {
            int initialValueAtLast = arrayToChange[Index];
            int parentIndex = Index / 2;

            while (arrayToChange[parentIndex] < initialValueAtLast)
            {
                arrayToChange[Index] = arrayToChange[parentIndex];
                Index = parentIndex;
                parentIndex = Index / 2;
            }

            arrayToChange[Index] = initialValueAtLast;
        }

        public void topDownApproach(int[] arrayToChange, int arrayToChangeLength )
        {
            for (int index = 2; index <= arrayToChangeLength; index++)
                restoreUpRandomArray(arrayToChange, index);

        }

        //returns the biggest value in the heap 
        public int DeleteRoot()
        {
            int rootValue = Heap[1];
            Heap[1] = Heap[currSize];
            currSize--;
            restoreDown(1);
            return rootValue;
        }

        public void restoreDown(int rootIndex)
        {
            //Three cases::
            //1. Both children are smaller than k : do nothing
            //2. If one child is greater than k: Greater child is moved up
            //3. If both children are greater than k: Larger of the two children is moved up 
            //*******************************************
            //Left Child of node N at index i: index 2i
            //Right Child of node N at index i: index (2i+1)

            int rootValue = Heap[rootIndex];

            int leftChildIndex = 2 * rootIndex;
            int rightChildIndex = 2 * rootIndex + 1;

            while (rightChildIndex <= currSize)
            {
                if (rootValue > Heap[leftChildIndex] && rootValue > Heap[rightChildIndex])
                {
                    Heap[rootIndex] = rootValue;
                    return;
                }
 
                else if (Heap[leftChildIndex] > Heap[rightChildIndex])
                {
                    Heap[rootIndex] = Heap[leftChildIndex];
                    rootIndex = leftChildIndex;
                }

                else 
                {
                    Heap[rootIndex] = Heap[rightChildIndex];
                    rootIndex = rightChildIndex;

                }

                leftChildIndex = 2 * rootIndex;
                rightChildIndex = 2 * rootIndex + 1;
            }

            if(leftChildIndex == currSize && rootValue < Heap[leftChildIndex])
            {
                Heap[rootIndex] = Heap[leftChildIndex];
                rootIndex = leftChildIndex;
            }
            Heap[rootIndex] = rootValue;

        }

        public void bottomUpApproach(int[] arrayToChange, int arrayToChangeCapacity)
        {
            for (int index = arrayToChangeCapacity/2; index >= 1; index--)
                restoreDownRandomArray(arrayToChange, index, arrayToChangeCapacity);

        }

        public void restoreDownRandomArray(int[] arrayToChange, int Index, int capacity)
        {
            //Three cases::
            //1. Both children are smaller than k : do nothing
            //2. If one child is greater than k: Greater child is moved up
            //3. If both children are greater than k: Larger of the two children is moved up 
            //*******************************************
            //Left Child of node N at index i: index 2i
            //Right Child of node N at index i: index (2i+1)

            int rootValue = arrayToChange[Index];

            int leftChildIndex = 2 * Index;
            int rightChildIndex = 2 * Index + 1;

            while (rightChildIndex <= capacity)
            {
                if (rootValue > arrayToChange[leftChildIndex] && rootValue > arrayToChange[rightChildIndex])
                {
                    arrayToChange[Index] = rootValue;
                    return;
                }

                else if (arrayToChange[leftChildIndex] > arrayToChange[rightChildIndex])
                {
                    arrayToChange[Index] = arrayToChange[leftChildIndex];
                    Index = leftChildIndex;
                }

                else
                {
                    arrayToChange[Index] = arrayToChange[rightChildIndex];
                    Index = rightChildIndex;

                }

                leftChildIndex = 2 * Index; 
                rightChildIndex = 2 * Index + 1;
            }

            if (leftChildIndex == capacity && rootValue < arrayToChange[leftChildIndex])
            {
                arrayToChange[Index] = arrayToChange[leftChildIndex];
                Index = leftChildIndex;
            }
            arrayToChange[Index] = rootValue;
        }



            public static void Main(string [] args)
        {
            MaxHeap a = new MaxHeap(15);
            Console.WriteLine(a.Capacity);
            Console.WriteLine(a.Heap[1]);
            Console.WriteLine(a.currSize);
          
            a.Insert(42);
            a.Insert(33);
            a.Insert(16);
            a.Insert(28);
            a.Insert(19);
            a.Insert(25);
            a.Insert(55);
            a.Insert(56);
            a.Insert(40);
            a.Insert(70);
            a.Insert(80);
            a.Insert(81);


            int index = 0;
            foreach(int element in a.Heap)
            {
                Console.WriteLine($"Element at index {index} is: {element} ");
                index++;
            }

            a.DeleteRoot();
            Console.WriteLine("--------------------------------------- ");
            index = 0;
            foreach (int element in a.Heap)
            {
                Console.WriteLine($"Element at index {index} is: {element} ");
                index++;
            }

            int[] aArray = { 99999, 1, 4, 5, 7, 9, 10 };
            int aCapacity = aArray.Length - 1;

            a.topDownApproach(aArray, aCapacity);
            foreach (int element in aArray)
            {
                Console.WriteLine($"Element is: {element} ");
                index++;
            }

            int[] bArray = { 99999, 1, 4, 5, 7, 9, 10 };
            int bCapacity = aArray.Length - 1;

            a.bottomUpApproach(bArray, bCapacity);
            foreach (int element in bArray)
            {
                Console.WriteLine($"Element is: {element} ");
                index++;
            }

        }

    }
}
