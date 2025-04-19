using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Bst_Project;

namespace BSTTests
{
    [TestClass]
    public class BSTTests
    {
        private string Clean(string input)
        {
            return input.Replace("\r", "").Replace("\n", "").Trim();
        }

        [TestMethod]
        public void PrintInOrder_EmptyTree_ShouldPrintNothing()
        {
            BST bst = new BST();

            using var sw = new StringWriter();
            Console.SetOut(sw);
            bst.PrintInOrder();
            string output = Clean(sw.ToString());

            Assert.AreEqual("InOrder:", output);
        }

        [TestMethod]
        public void Insert_ShouldPrintSortedOrder()
        {
            BST bst = new BST();
            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(10);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            bst.PrintInOrder();
            string output = Clean(sw.ToString());

            Assert.AreEqual("InOrder: 3 8 10", output);
        }

        [TestMethod]
        public void Search_NodeExists_ShouldReturnTrue()
        {
            BST bst = new BST();
            bst.Insert(5);
            bst.Insert(2);
            bst.Insert(8);

            Assert.IsTrue(bst.Search(2));
            Assert.IsTrue(bst.Search(5));
            Assert.IsTrue(bst.Search(8));
        }

        [TestMethod]
        public void Search_NodeDoesNotExist_ShouldReturnFalse()
        {
            BST bst = new BST();
            bst.Insert(1);
            bst.Insert(3);

            Assert.IsFalse(bst.Search(99));
        }

        [TestMethod]
        public void Delete_LeafNode_ShouldRemoveCorrectly()
        {
            BST bst = new BST();
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Delete(5); // hoja

            using var sw = new StringWriter();
            Console.SetOut(sw);
            bst.PrintInOrder();
            string output = Clean(sw.ToString());

            Assert.AreEqual("InOrder: 10 15", output);
        }

        [TestMethod]
        public void Delete_NodeWithOneChild_ShouldWork()
        {
            BST bst = new BST();
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(3); // hijo izquierdo

            bst.Delete(5);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            bst.PrintInOrder();
            string output = Clean(sw.ToString());

            Assert.AreEqual("InOrder: 3 10", output);
        }

        [TestMethod]
        public void Delete_NodeWithTwoChildren_ShouldWork()
        {
            BST bst = new BST();
            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(14);
            bst.Insert(13);

            bst.Delete(3);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            bst.PrintInOrder();
            string output = Clean(sw.ToString());

            Assert.AreEqual("InOrder: 1 6 8 10 13 14", output);
        }

        [TestMethod]
        public void PrintPreOrder_ShouldPrintCorrectOrder()
        {
            BST bst = new BST();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(7);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            bst.PrintPreOrder();
            string output = Clean(sw.ToString());

            Assert.AreEqual("PreOrder: 5 3 7", output);
        }

        [TestMethod]
        public void PrintPostOrder_ShouldPrintCorrectOrder()
        {
            BST bst = new BST();
            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(7);

            using var sw = new StringWriter();
            Console.SetOut(sw);
            bst.PrintPostOrder();
            string output = Clean(sw.ToString());

            Assert.AreEqual("PostOrder: 3 7 5", output);
        }
    }
}

