using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreePractice
{
   public class BinaryTree
    {
        public TreeNode Root { get; set; }
        public int Count { get; set; }
        public int[] Output { get; set; }
        public int Index { get; set; }

        public BinaryTree(int x)
        {
            Root = new TreeNode(x);
            Count = 1;
            Index = 0;
        }

        public void addToTree(int dataToAdd)
        {
            addNode(Root, dataToAdd);
        }

        private TreeNode addNode(TreeNode aNode, int dataToAdd)
        {
            //if (aNode.Data > dataToAdd)
            //{
            //    if (aNode.Left == null)
            //        aNode.Left = new TreeNode(dataToAdd);
            //    else
            //        addNode(aNode.Left, dataToAdd);

            //}

            //else if (aNode.Data < dataToAdd)
            //{
            //    if (aNode.Right == null)
            //        aNode.Right = new TreeNode(dataToAdd);
            //    else
            //        addNode(aNode.Right, dataToAdd);

            //}

            //else
            //    Console.WriteLine("This node exist in the tree already!!!");

            if (aNode == null)
            {
                aNode = new TreeNode(dataToAdd);
                Count++;
            }
                

            else if(aNode.Data > dataToAdd)
            {
                aNode.Left = addNode(aNode.Left, dataToAdd);
            }

            else if(aNode.Data < dataToAdd)
            {
                aNode.Right = addNode(aNode.Right, dataToAdd);
            }

            else
                Console.WriteLine("A node with this data already exist. Not Doing anything!");

            return aNode;
            
        }
        public TreeNode getNode(int dataToFind)
        {
            return findNode(Root, dataToFind);
        }

        public Boolean dataExist(int dataToFind)
        {
            if (findNode(Root, dataToFind) == null)
                return false;
            else
                return true;
        }
        private TreeNode findNode(TreeNode aNode, int dataToFind)
        {
            if (aNode == null)
                return null;
            else if(aNode.Data == dataToFind)
                return aNode;
            else if (aNode.Data > dataToFind)
                return findNode(aNode.Left, dataToFind);
            else 
                return findNode(aNode.Right, dataToFind);
        }

        public TreeNode leftOrRight(int dataToCompare, TreeNode nodeToCompare)
        {
            if (dataToCompare > nodeToCompare.Data)
                return nodeToCompare.Right;
            else
                return nodeToCompare.Left;
        }
        public Boolean remove(int dataToRemove)
        {
            TreeNode childNode;

            if (Root.Data > dataToRemove)
                childNode = Root.Left;
            else
                childNode = Root.Right;

            if (removeFromTree(dataToRemove, childNode, Root) == false)
                return false;

            else
            {
                Count--;
                return true;
            }

        }
        public Boolean removeFromTree(int dataToRemove, TreeNode toDelete, TreeNode delParent)
        {
            //Case 1: The node to delete doesn't exist, do nothing.
            if (getNode(dataToRemove) == null)
            {
                Console.WriteLine("Not happening !!!");
                return false;
            }

            if(toDelete.Data != dataToRemove)
            {
                delParent = toDelete;
                Console.WriteLine("Delparents :" + delParent.Data);
                toDelete = leftOrRight(dataToRemove, toDelete);
                Console.WriteLine("toDelete :" + toDelete.Data);
                removeFromTree(dataToRemove, toDelete, delParent);
            }

            //Case 2: The node to delete doesn't have children, its a leaf Node
            else if (toDelete.Right == null && toDelete.Left == null)
            {
                Console.WriteLine("Im here now!!! Case 2");
                if (dataToRemove > delParent.Data)
                    delParent.Right = null;
                else
                    delParent.Left = null;

                return true;
            }

            //Case 3: Non-Leaf Node. We need to find the child to replace the delete node. Three subcases
            //Case 3a: The node to delete, has no right child. First find the node to remove.
            //         Remember it has a left child, and we need to make the left child replace the node to delete.
            else if(toDelete.Right == null)
            {
                if (dataToRemove > delParent.Data)
                {
                    delParent.Right = toDelete.Left;
                }
                else
                {
                    delParent.Left = toDelete.Left;
                }
               

                return true;
            }

            //Case 3b: The node to delete, (has a right child who does not have a left child).
            //Steps: Find node to remove. Node to remove's right child has no left child. node to remove right child replaces node to remove. 
            else if(toDelete.Right.Left == null)
            {
                toDelete.Right.Left = toDelete.Left;

                if (dataToRemove > delParent.Data)
                {
                    delParent.Right = toDelete.Right;
                }
                else
                {
                    delParent.Left = toDelete.Right;
                }
                return true;
            }

            //Case 3c: The node to delete, (has a right child who has a left child).
            //Step: Find note to remove, the right child has a left child, find right's left most child. 



            //     3b: The node to remove has no left child. It ONLY has right childs. 
            //         Promote right child. Remember this has to the parent of node children that has be removed.
            //
            //     3c: Remove right child has left child.
            //         Right child's left most child replaces removed. The left most child will replace node to delete.
            else if(toDelete.Right.Left != null)
            {
                TreeNode leftMost = toDelete.Right.Left;
                TreeNode leftMostParent = toDelete.Right;

                while(leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;
                leftMost.Left = toDelete.Left;
                leftMost.Right = toDelete.Right;


                if (dataToRemove > delParent.Data)
                {
                    delParent.Right = leftMost;
                }
                else
                {
                    delParent.Left = leftMost;
                }


            }
            return true;
        }

        public int getCount()
        {
            return Count;
        }
        public void preOrder()
        {
            Output = new int[Count];
            Index = 0;
            preOrderTraversal(Root);
        }
        public void preOrderTraversal(TreeNode aNode)
        {
            if(aNode != null)
            {
                Output[Index++] = aNode.Data;
                preOrderTraversal(aNode.Left);
                preOrderTraversal(aNode.Right);
            }

           
        }

        public void inOrder()
        {
            Output = new int[Count];
            Index = 0;
            inOrderTraversal(Root);
        }

        public void inOrderTraversal(TreeNode aNode)
        {
            if (aNode != null)
            {
                inOrderTraversal(aNode.Left);
                Output[Index++] = aNode.Data;
                inOrderTraversal(aNode.Right);
            }

        }

        public void postOrder()
        {
            Output = new int[Count];
            Index = 0;
            postOrderTraversal(Root);
        }

        public void postOrderTraversal(TreeNode aNode)
        {
            if (aNode != null)
            {
                postOrderTraversal(aNode.Left);
                postOrderTraversal(aNode.Right);
                Output[Index++] = aNode.Data;
            }
        }

        public void levelOrder()
        {
            Output = new int[Count];
            Index = 0;
            levelOrderTraversal(Root);
        }

        public void levelOrderTraversal(TreeNode aNode)
        {
            //Steps:
            //1: Add the node
            //2: Add the nodes left and right children
            //3: Remove first node added, and gets it data
            //4: Repeat steps 2-3 with the nodes in the queue
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(aNode);

            while (queue.Count > 0)
            {
                aNode = queue.Peek();
                //[0] = 4, [1] = 2, [2] = 5 . [3] = 1, [4] = 3, [5] = 7, [6] = 6, [7] = 8
                // 8
                if (aNode.Left != null)
                queue.Enqueue(aNode.Left);
                if(aNode.Right != null)
                queue.Enqueue(aNode.Right);
                Output[Index++] = queue.Dequeue().Data;

                //        4
                //       / \
                //      2   5
                //     / \   \
                //    1   3   7
                //           / \
                //          6   8
            }
        }
    }
}
