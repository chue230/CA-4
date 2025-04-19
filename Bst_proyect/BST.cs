using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using Bst_proyect;

namespace Bst_project
{
    public class BST
    {
        public BSTNode? Root;

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
            int minv = node.Value;
            while (node.Left != null)
            {
                minv = node.Left.Value;
                node = node.Left;
            }
            return minv;
        }

        public List<int> InOrder()
        {
            List<int> result = new();
            InOrderRecursive(Root, result);
            return result;
        }

        private void InOrderRecursive(BSTNode? node, List<int> result)
        {
            if (node != null)
            {
                InOrderRecursive(node.Left, result);
                result.Add(node.Value);
                InOrderRecursive(node.Right, result);
            }
        }
    }
}
