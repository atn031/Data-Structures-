using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackPractice;
using LinkedListPractice;

namespace StackTesting
{
    [TestClass]
    public class StackImplementationTesting_LinkedList
    {
        [TestMethod]
        public void Stack_IsEmpty()
        {
            Stack<int> aStack = new Stack<int>();

            Assert.IsTrue(aStack.isEmpty());            
        }

        [TestMethod]
        public void Stack_isNotEmpty()
        {
            Stack<int> aStack = new Stack<int>();

            aStack.push(1);

            Assert.IsFalse(aStack.isEmpty());
        }

        [TestMethod]
        public void Stack_PopandPeek_EmptyStack_ExceptionMessageCheck()
        {
            Stack<int> aStack = new Stack<int>();

            var exception1 = Assert.ThrowsException<NullReferenceException>(() => aStack.peek());
            var exception2 = Assert.ThrowsException<NullReferenceException>(() => aStack.pop());

            Assert.AreEqual(exception1.Message, "The stack doesn't have any elements");
            Assert.AreEqual(exception2.Message, "The stack doesn't have any elements");

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Stack_PopandPeek_EmptyStackeck()
        {
            Stack<int> aStack = new Stack<int>();

            aStack.peek();
            aStack.pop();
        }

        [TestMethod]
        public void Stack_ElementsAddedSuccessful()
        {
            Stack<int> aStack = new Stack<int>();
            int[] elementsToVerify = { 5,10,15,20,25,30,50,100};

            aStack.push(5);
            aStack.push(10);
            aStack.push(15);
            aStack.push(20);
            aStack.push(25);
            aStack.push(30);
            aStack.push(50);
            aStack.push(100);

            foreach(int elements in elementsToVerify)
            {
                Assert.IsTrue(aStack.search(elements));
            }

        }

        [TestMethod]
        public void Stack_PopOrderCorrect()
        {
            Stack<int> aStack = new Stack<int>();
            int[] elementsToVerify = { 5, 10, 15, 20, 25, 30, 50, 100 };
            Array.Reverse(elementsToVerify);

            aStack.push(5);
            aStack.push(10);
            aStack.push(15);
            aStack.push(20);
            aStack.push(25);
            aStack.push(30);
            aStack.push(50);
            aStack.push(100);


            foreach (int elements in elementsToVerify)
            {
                Assert.AreEqual(aStack.pop().Value, elements);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Stack_TestFunctionRobustness_InsertRemoveFromStack()
        {
            Stack<int> aStack = new Stack<int>();
            int[] elementsToVerify = { 5, 10, 15, 20, 25, 10, 20, 30, 40, 50};
            Array.Reverse(elementsToVerify);

            //add 5,10,15,20,25,30,35,40,45,50
            for(int i = 5; i <= 50; i += 5)
            {
                aStack.push(i);
            }
            
            //remove 50,45,40,35,30
            for (int i = 0; i < 5; i++)
            {
                aStack.pop();
            }

            //add 10,20,30,40,50
            for (int i = 10; i <= 50; i += 10)
            {
                aStack.push(i);
            }

            //first element to be removed should be 50 not 25
            foreach (int elements in elementsToVerify)
            {
                Assert.AreEqual(aStack.pop().Value, elements);
            }

            aStack.pop();

        }
    }
}
