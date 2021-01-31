using System;

namespace DataStructures.BinarySearchTree
{
	public class Tree
	{
		private class Node
		{
			public int Value;
			public Node LeftChild;
			public Node RightChild;
			public Node(int value)
			{
				Value = value;
				//System.Console.WriteLine(Value);
			}
			public override string ToString()
			{
				return $"{Value}";
			}
		}

		private Node Root;

		public void Insert(int value)
		{
			var node = new Node(value);

			if (Root == null)
			{
				Root = node;
				return;
			}

			var current = Root;
			while (true)
			{
				if (value < current.Value)
				{
					if (current.LeftChild == null)
					{
						current.LeftChild = node;
						break;
					}
					current = current.LeftChild;
				}
				if (value > current.Value)
				{
					if(current.RightChild == null)
					{
						current.RightChild = node;
						break;
					}
					current = current.RightChild;
				}
			}
		}

		public bool Find(int value)
		{
			var current = Root;
			while(current != null)
			{
				if (value < current.Value)
					current = current.LeftChild;
				else if (value > current.Value)
					current = current.RightChild;
				else return true;
			}
			return false;
		}

		public void PreOrderTraverse() => PreOrderTraverse(Root);
		
		public void InOrderTraverse() => InOrderTraverse(Root);

		public void PostOrderTraverse() => PostOrderTraverse(Root);

		public void Height()
		{
			Console.WriteLine($"{Height(Root)}");
		}

		/// <summary>
		/// Finding min value in binary search tree
		/// </summary>
		/// <returns>Minumum value in binary search tree</returns>
		public int Min()
		{
			var current = Root;
			var node = Root;
			while(current != null)
			{
				node = current;
				current = current.LeftChild;
			}
			return node.Value;
		}

		public int MinOfBinaryTree()
		{
			return Min(Root);
		}

		public override bool Equals(object obj)
		{
			var tree = obj as Tree;
			if (tree == null) return false;
			return IsEquals(Root, tree.Root);
		}

		public bool IsBinarySearchTree()
		{
			return IsBinarySearchTree(Root, int.MinValue, int.MaxValue);
		}

		public void Swap()
		{
			var temp = Root.LeftChild;
			Root.LeftChild = Root.RightChild;
			Root.RightChild = temp;
		}

		public void PrintNodeAtDistance(int distance) =>  PrintNodeAtDistance(Root, distance);

		public void TraverseLevelOrder()
		{
			for (int i = 0; i <= Height(Root); i++)
				PrintNodeAtDistance(i);
		}

		private void PrintNodeAtDistance(Node node, int distance)
		{
			if (node == null) return;
			if (distance == 0)
			{
				Console.WriteLine(node.Value);
				return;
			}

			PrintNodeAtDistance(node.LeftChild, distance-1);
			PrintNodeAtDistance(node.RightChild, distance-1);
		}

		private bool IsBinarySearchTree(Node root, int min, int max)
		{
			if (root == null) return true;

			if (root.Value < min || root.Value > max) return false;

			return IsBinarySearchTree(root.LeftChild, min, root.Value - 1) &&
				   IsBinarySearchTree(root.RightChild, root.Value + 1, max);
		}

		private bool IsEquals(Node firstTreeRoot, Node secondTreeRoot)
		{
			if (firstTreeRoot == null && secondTreeRoot == null) return true;

			if(firstTreeRoot != null && secondTreeRoot != null)
				return firstTreeRoot.Value == secondTreeRoot.Value &&
					   IsEquals(firstTreeRoot.LeftChild, secondTreeRoot.LeftChild) &&
					   IsEquals(firstTreeRoot.RightChild, secondTreeRoot.RightChild);

			return false;
		}

		private int Min(Node root)
		{
			if (IsLeaf(root)) return root.Value;

			var left = Min(root.LeftChild);
			var right = Min(root.RightChild);
			return Math.Min(Math.Min(left, right), root.Value);
		}

		private bool IsLeaf(Node root)
		{
			return (root.LeftChild == null && root.RightChild == null);
		}

		private int Height(Node root)
		{
			if (root == null) return -1;
			if(IsLeaf(root))  return 0;

			return 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
		}

		private void PreOrderTraverse(Node root)
		{
			if (root == null) return;
			Console.Write($"{root.Value},");
			PreOrderTraverse(root.LeftChild);
			PreOrderTraverse(root.RightChild);
		}

		private void InOrderTraverse(Node root)
		{
			if (root == null) return;
			InOrderTraverse(root.LeftChild);
			Console.Write($"{root.Value},");
			InOrderTraverse(root.RightChild);
		}

		private void PostOrderTraverse(Node root)
		{
			if (root == null) return;
			PostOrderTraverse(root.LeftChild);
			PostOrderTraverse(root.RightChild);
			Console.Write($"{root.Value},");
		}
	}
}
