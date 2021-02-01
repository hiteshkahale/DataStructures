using DataStructures.AVL;
using DataStructures.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
	class Program
	{
		static void Main(string[] args)
		{
			//ExecuteBinaryTreeExample();
			ExecuteAVLExample();
			Console.ReadLine();
		}

		private static void ExecuteAVLExample()
		{
			var avl = new AVLTree();
			avl.Insert(10);
			avl.Insert(30);
			avl.Insert(20);
		}

		private static void ExecuteBinaryTreeExample()
		{
			// Insert
			var tree = new Tree();
			tree.Insert(7);
			tree.Insert(4);
			tree.Insert(9);
			tree.Insert(1);
			tree.Insert(6);
			tree.Insert(8);
			tree.Insert(10);

			tree.TraverseLevelOrder();

			//tree.PrintNodeAtDistance(1);

			// Is a Binary Search Tree?
			/*tree.Swap();
			Console.WriteLine(tree.IsBinarySearchTree()); */

			// Equality Check
			/*var tree2 = new Tree();
			tree2.Insert(7);
			tree2.Insert(4);
			tree2.Insert(9);
			tree2.Insert(1);
			tree2.Insert(6);
			tree2.Insert(8);
			//tree2.Insert(10);

			// IsEquals
			Console.WriteLine(tree.Equals(tree2)); */

			// Find
			//Console.WriteLine(tree.Find(11));

			// Depth First Traverse
			/*
			// 1. Pre-Order
			Console.WriteLine("\n1. Pre-Order Travere");
			tree.PreOrderTraverse();
			// 2. In-Order
			Console.WriteLine("\n2. In-Order Traverse");
			tree.InOrderTraverse();
			// 3. Post-Order
			Console.WriteLine("\n3. Post-Order Traverse");
			tree.PostOrderTraverse(); */

			// Height
			//tree.Height();

			// Minimum value
			//Console.WriteLine($"Minimum value in tree is {tree.Min()}");
		}
	}
}
