using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListPractice;
using QueuePractice;

namespace QueueImplementationTesting
{
    [TestClass]
    public class QueueTesting_LinkedListUnitTest
    {
        [TestMethod]
        public void QueueisEmptyCheck()
        {
            Queue<int> aQueue = new Queue<int>();

            Assert.IsTrue(aQueue.isEmpty());
        }

        [TestMethod]
        public void Queue_InsertWorksCorrectly()
        {
            Queue<int> aQueue = new Queue<int>();

            for (int addElement = 0; addElement < 10; addElement++)
            {
                aQueue.Enqueue(addElement);
                Assert.AreEqual(addElement, aQueue.peek().Value);
                aQueue.Dequeue();
            }
        }

        [TestMethod]
        public void Queue_ContainsTheValues()
        {
            Queue<int> aQueue = new Queue<int>();

            for(int element = 0; element <= 100; element++)
            {
                aQueue.Enqueue(element);
                Assert.IsTrue(aQueue.getNodeWithElement(element)); 
            }

        }

        [TestMethod]
        public void Queue_DequeueRemovesElementsInCorrecOrder()
        {
            Queue<int> aQueue = new Queue<int>();
            int[] arrayToCompare = { 1, 2, 3, 4, 5};
            int[] arrayToCompare2 = {6, 7, 8, 9, 10, 5, 5};

            for (int addElement = 1; addElement < arrayToCompare.Length+6; addElement++)
            {
                aQueue.Enqueue(addElement);
            }
            foreach (int element in arrayToCompare)
            {
                Assert.AreEqual(element, aQueue.Dequeue().Value);

            }

            //two fives will be added to the end of the list
            aQueue.Enqueue(5);
            aQueue.Enqueue(5);

            foreach (int element in arrayToCompare2)
            {
                Assert.AreEqual(element, aQueue.Dequeue().Value);
            }
        }

        [TestMethod]
        public void Queue_NoLongerContainsValuesAfterDequeue()
        {
            Queue<int> aQueue = new Queue<int>();
            int[] arrayToCompare = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int addElement = 1; addElement < arrayToCompare.Length + 1; addElement++)
            {
                aQueue.Enqueue(addElement);
            }

            for (int addElement = 1; addElement < arrayToCompare.Length + 1; addElement++)
            {
                aQueue.Dequeue();
            }


            for (int Element = 1; Element < arrayToCompare.Length + 1; Element++)
            {
                Assert.IsFalse(aQueue.getNodeWithElement(Element));
            }

            Assert.IsTrue(aQueue.isEmpty());

        }
    }
}
