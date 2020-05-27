using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreePractice;

namespace BinaryTreeTest
{
    [TestClass]
    public class BinaryTree_Verification
    {
        [TestMethod]
        public void creatingBinaryTree()
        {
            BinaryTree one = new BinaryTree(4);
            Assert.IsNotNull(one);
            Assert.IsNull(one.Root.Left);
            Assert.IsNull(one.Root.Right);
            Assert.AreEqual(one.Root.Data, 4);
        }
        [TestMethod]
        public void addDataToRoot_LeftRight()
        {
            BinaryTree one = new BinaryTree(5);

            one.addToTree(2);
            one.addToTree(7);

            Assert.IsNotNull(one.Root.Left);
            Assert.IsNotNull(one.Root.Right);

            Assert.AreEqual(one.Root.Left.Data, 2);
            Assert.AreEqual(one.Root.Right.Data, 7);

            Assert.IsNull(one.Root.Left.Left);
            Assert.IsNull(one.Root.Right.Right);
        }

        [TestMethod]
        public void InOrderTraversal()
        {
            BinaryTree aTree = new BinaryTree(4);
            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            aTree.addToTree(2);
            aTree.addToTree(5);
            aTree.addToTree(7);
            aTree.addToTree(3);
            aTree.addToTree(1);
            aTree.addToTree(6);
            aTree.addToTree(8);
            aTree.inOrder();
            int[] expected= { 1, 2, 3, 4, 5, 6, 7, 8 };
            int index = 0;
            foreach(int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }

        }

        [TestMethod]
        public void PreOrderTraversal()
        {
            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(5);
            aTree.addToTree(2);
            aTree.addToTree(7);
            aTree.addToTree(3);
            aTree.addToTree(6);
            aTree.addToTree(1);
            aTree.addToTree(8);
            aTree.preOrder();

            int[] expected = { 4, 2, 1, 3, 5, 7, 6, 8};
            int index = 0;
            foreach (int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }
        }

        [TestMethod]
        public void PostOrderTraversal()
        {
            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(5);
            aTree.addToTree(2);
            aTree.addToTree(7);
            aTree.addToTree(3);
            aTree.addToTree(6);
            aTree.addToTree(1);
            aTree.addToTree(8);
            aTree.postOrder();

            int[] expected = { 1, 3, 2, 6, 8, 7, 5, 4 };
            int index = 0;
            foreach (int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }

        }

        [TestMethod]
        public void LevelOrderTraversal()
        {
            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(5);
            aTree.addToTree(2);
            aTree.addToTree(7);
            aTree.addToTree(3);
            aTree.addToTree(6);
            aTree.addToTree(1);
            aTree.addToTree(8);
            aTree.levelOrder();

            int[] expected = { 4, 2, 5, 1, 3, 7, 6, 8 };
            int index = 0;
            foreach (int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }

        }

        [TestMethod]
        public void removeNode_NoLeftChild()
        {
            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8
            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(5);
            aTree.addToTree(2);
            aTree.addToTree(7);
            aTree.addToTree(3);
            aTree.addToTree(6);
            aTree.addToTree(1);
            aTree.addToTree(8);

            Assert.IsTrue(aTree.remove(5), "Remove should return true for found node");

            //        4
            //       /  \
            //      2    6
            //     / \    \
            //    1   3    7
            //              \
            //               8

            int[] expected = new[] { 1, 3, 2, 8, 7, 6, 4 };
            int index = 0;
            aTree.postOrder();
            foreach (int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }
        }

        [TestMethod]
        public void removeNode_RightLeaf()
        {
            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8
            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(5);
            aTree.addToTree(2);
            aTree.addToTree(7);
            aTree.addToTree(3);
            aTree.addToTree(6);
            aTree.addToTree(1);
            aTree.addToTree(8);

            Assert.IsTrue(aTree.remove(8), "Remove should return true for found node");

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           /
            //          6


            int[] expected = new[] { 1, 3, 2, 6, 7, 5, 4 };
            int index = 0;
            aTree.postOrder();
            foreach (int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }
        }

        [TestMethod]
        public void removeNode_LeftLeaf()
        {
            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8
            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(5);
            aTree.addToTree(2);
            aTree.addToTree(7);
            aTree.addToTree(3);
            aTree.addToTree(6);
            aTree.addToTree(1);
            aTree.addToTree(8);

            Assert.IsTrue(aTree.remove(1), "Remove should return true for found node");

            //        4
            //       / \
            //      2   5
            //     / \   \
            //        3   7
            //           / \
            //          6   8


            int[] expected = new[] { 3, 2, 6, 8, 7, 5, 4 };
            int index = 0;
            aTree.postOrder();
            foreach (int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }
        }

        [TestMethod]
        public void remove_CurrentRight_HasNoLeft()
        {
            //         4
            //       /   \
            //      2     6
            //     / \    /\
            //    1   3  5  7
            //               \
            //                8

            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(2);
            aTree.addToTree(6);
            aTree.addToTree(1);
            aTree.addToTree(3);
            aTree.addToTree(5);
            aTree.addToTree(7);
            aTree.addToTree(8);

            Assert.IsTrue(aTree.remove(6), "Remove should return true for found node");

            //          4
            //       /    \
            //      2      7
            //     / \    / \
            //    1   3  5   8


            int[] expected = new[] {1, 3, 2, 5, 8, 7, 4};
            int index = 0;
            aTree.postOrder();
            foreach (int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }
        }

        [TestMethod]
        public void remove_Current_HasNoRight()
        {
            //         4
            //       /   \
            //      2     8 
            //     / \    /
            //    1   3  6
            //          / \
            //         5   7   

            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(2);
            aTree.addToTree(8);
            aTree.addToTree(1);
            aTree.addToTree(3);
            aTree.addToTree(6);
            aTree.addToTree(5);
            aTree.addToTree(7);

            Assert.IsTrue(aTree.remove(8), "Remove should return true for found node");

            //         4
            //       /   \
            //      2      6 
            //     / \    / \
            //    1   3  5   7


            int[] expected = new[] { 1, 3, 2, 5, 7, 6, 4 };
            int index = 0;
            aTree.postOrder();
            foreach (int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }
        }

        [TestMethod]
        public void remove_CurrentRight_HasLeft()
        {
            //         4
            //       /    \
            //      2      6 
            //     / \    / \
            //    1   3  5   8
            //              /
            //             7 

            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(2);
            aTree.addToTree(6);
            aTree.addToTree(1);
            aTree.addToTree(3);
            aTree.addToTree(5);
            aTree.addToTree(8);
            aTree.addToTree(7);

            Assert.IsTrue(aTree.remove(6), "Remove should return true for found node");

            //         4
            //       /    \
            //      2      7 
            //     / \    / \
            //    1   3  5   8


            int[] expected = new[] { 1, 3, 2, 5, 8, 7, 4 };
            int index = 0;
            aTree.postOrder();
            foreach (int actual in aTree.Output)
            {
                Assert.AreEqual(expected[index++], actual);
            }
        }



        [TestMethod]
        public void findNonExistentData()
        {
            BinaryTree aTree = new BinaryTree(4);
            aTree.addToTree(2);
            aTree.addToTree(6);
            aTree.addToTree(1);
            aTree.addToTree(3);
            aTree.addToTree(5);
            aTree.addToTree(8);
            aTree.addToTree(7);

            Assert.IsFalse(aTree.dataExist(10));

        }

    }
}
