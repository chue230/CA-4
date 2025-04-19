using System;
using Bst_proyect;

namespace Bst_Project
{
    public class BST
    {
        public BSTNode? Root;

        // -------------------- INSERT --------------------
        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        private BSTNode InsertRecursive(BSTNode? node, int value)
        {
            if (node == null) return new BSTNode(value);

            if (value < node.Value)
                node.Left = InsertRecursive(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertRecursive(node.Right, value);

            return node;
        }

        // -------------------- SEARCH --------------------
        public bool Search(int value)
        {
            return SearchRecursive(Root, value);
        }

        private bool SearchRecursive(BSTNode? node, int value)
        {
            if (node == null) return false;
            if (value == node.Value) return true;

            return value < node.Value
                ? SearchRecursive(node.Left, value)
                : SearchRecursive(node.Right, value);
        }

        // -------------------- DELETE --------------------
        public void Delete(int value)
        {
            Root = DeleteRecursive(Root, value);
        }

        private BSTNode? DeleteRecursive(BSTNode? root, int key)
        {
            if (root == null) return root;

            if (key < root.Value)
                root.Left = DeleteRecursive(root.Left, key);
            else if (key > root.Value)
                root.Right = DeleteRecursive(root.Right, key);
            else
            {
                if (root.Left == null) return root.Right;
                if (root.Right == null) return root.Left;

                root.Value = MinValue(root.Right);
                root.Right = DeleteRecursive(root.Right, root.Value);
            }

            return root;
        }

        private int MinValue(BSTNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.Value;
        }

        // -------------------- INORDER --------------------
        public void PrintInOrder()
        {
            Console.Write("InOrder: ");
            PrintInOrderRecursive(Root);
            Console.WriteLine();
        }

        private void PrintInOrderRecursive(BSTNode? node)
        {
            if (node == null) return;
            PrintInOrderRecursive(node.Left);
            Console.Write(node.Value + " ");
            PrintInOrderRecursive(node.Right);
        }

        // -------------------- PREORDER --------------------
        public void PrintPreOrder()
        {
            Console.Write("PreOrder: ");

            PrintPreOrderRecursive(Root);
            Console.WriteLine();
        }

        private void PrintPreOrderRecursive(BSTNode? node)
        {
            if (node == null) return;
            Console.Write(node.Value + " ");
            PrintPreOrderRecursive(node.Left);
            PrintPreOrderRecursive(node.Right);
        }

        // -------------------- POSTORDER --------------------
        public void PrintPostOrder()
        {
   

            Console.Write("PostOrder: "  );
            PrintPostOrderRecursive(Root);
            Console.WriteLine();
        }

        private void PrintPostOrderRecursive(BSTNode? node)
        {
            if (node == null) return;
            PrintPostOrderRecursive(node.Left);
            PrintPostOrderRecursive(node.Right);
            Console.Write(node.Value + " ");
        }
    }
}
