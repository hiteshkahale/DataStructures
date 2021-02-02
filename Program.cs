using DataStructures.AVL;
using DataStructures.Heap;
using DataStructures.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs;

namespace DataStructures
{
	class Program
	{
		static void Main(string[] args)
		{
			//ExecuteBinaryTreeExample();
			//ExecuteAVLExample();
			//ExecuteHeapExample();
			//ExecuteTrieExample();
			ExecuteGraphExample();
			Console.ReadLine();
		}

		private static void ExecuteGraphExample()
		{
			// HasCycle
			var graph = new Graph();
			graph.AddNode("A");
			graph.AddNode("B");
			graph.AddNode("C");
			graph.AddEdge("A", "B");
			graph.AddEdge("B", "C");
			graph.AddEdge("C", "A");
			Console.WriteLine(graph.HasCycle());

			/*
			// Topological Sort
			var graph = new Graph();
			graph.AddNode("X");
			graph.AddNode("A");
			graph.AddNode("B");
			graph.AddNode("P");
			graph.AddEdge("X", "A");
			graph.AddEdge("X", "B");
			graph.AddEdge("A", "P");
			graph.AddEdge("B", "P");
			var list = graph.TopologicalSort();
			Console.WriteLine(string.Join(",", list));
			*/

			// Add, remove node and edge
			/*var graph = new Graph();
			graph.AddNode("A");
			graph.AddNode("B");
			graph.AddNode("C");
			graph.AddEdge("A", "B");
			graph.AddEdge("A", "C"); */
			//graph.RemoveEdge("A","B");
			//graph.Print();

			// Traverse
			// Depth first 
			// graph.TraverseDepthFirst("A"); // Recursive
			// graph.TraverseDepthFirstIterative("A"); // Iterative
			// Breadth first
			// graph.TraverseBreadthFirstIterative("A");
		}

		private static void ExecuteTrieExample()
		{
			// Autocompletion

			var trie = new Trie.Trie();
			trie.Insert("car");
			trie.Insert("care");
			trie.Insert("card");
			trie.Insert("careful");
			trie.Insert("egg");
			Console.WriteLine(string.Join(",", trie.FindWords(null)));
			// Remove
			/*var trie = new Trie.Trie();
			trie.Insert("care");
			trie.Insert("car");
			trie.Remove("car");
			trie.Remove("care");
			Console.WriteLine(trie.Contains("car"));
			Console.WriteLine(trie.Contains("care"));*/

			/*var trie = new Trie.Trie();
			trie.Insert("care");
			trie.Traverse();*/
		}

		private static void ExecuteHeapExample()
		{
			// Heapify
			var array = new int[] { 5, 3, 15, 20, 1, 4 };
			//MaxHeap.Heapify(array);
			//Console.WriteLine(string.Join(",", array));

			// Kth Largest
			Console.WriteLine(MaxHeap.GetKthLargest(array,5));

			// Heap Sort
			/*var array = new int[]{ 5, 3, 15, 20, 1, 4 };
			var heap = new Heap.Heap(array.Length);
			foreach (var item in array)
				heap.Insert(item);

			// Ascending Order
			for (int i = array.Length - 1 ; i >= 0; i--)
				array[i] = heap.Remove();

			Console.WriteLine(string.Join(",", array)); */

			/*
			var heap = new Heap.Heap(10);
			heap.Insert(10);
			heap.Insert(5);
			heap.Insert(17);
			heap.Insert(22);

			// In heap can remove only item at root
			heap.Remove(); */
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
