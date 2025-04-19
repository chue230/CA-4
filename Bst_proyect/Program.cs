using System;
using Bst_Project;

namespace Bst_proyect
{
    class Program
    {
        static void Main(string[] args)
        {
            BST bst = new BST();
            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(6);

            
            Console.WriteLine("\nBuscar 897: " + (bst.Search(897) ? "Sí está" : "No está"));
        }
    }
}
