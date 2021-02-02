using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Trie
{
	public class Trie
	{
		private class Node
		{
			public char Value;
			public Dictionary<char, Node> Children = new Dictionary<char, Node>();
			public bool IsEndOfWord { get; set; }

			public Node(char value)
			{
				Value = value;
			}

			public override string ToString()
			{
				return $"{Value}";
			}

			public IList<Node> GetChildren()
			{
				return Children.Values.ToList();
			}
		}

		private Node Root = new Node(' ');

		public void Insert(string word)
		{
			var current = Root;
			foreach (var ch in word.ToCharArray())
			{
				if (!current.Children.ContainsKey(ch))
					current.Children[ch] = new Node(ch);
				current = current.Children[ch];
			}
			current.IsEndOfWord = true;
		}

		public bool Contains(string word)
		{
			if (string.IsNullOrEmpty(word)) return false;

			var current = Root;
			foreach (var ch in word.ToCharArray())
			{
				if (!current.Children.ContainsKey(ch))
					return false;
				current = current.Children[ch];
			}
			return current.IsEndOfWord;
		}

		public void Traverse() => Traverse(Root);

		private void Traverse(Node root)
		{
			var current = root;

			// Pre-Order Traversal
			Console.WriteLine(current.Value);

			foreach (var node in current.GetChildren())
				Traverse(node);

			// Post-Order Traversal
			//Console.WriteLine(current.Value);
		}

		public void Remove(string word)
		{
			if (string.IsNullOrEmpty(word)) return;
			Remove(Root, word, 0);
		}

		private void Remove(Node root, string word, int index)
		{
			if(index == word.Length)
			{
				root.IsEndOfWord = false;
				return;
			}

			var ch = word[index];
			if (!root.Children.ContainsKey(ch)) return;

			var child = root.Children[ch];

			Remove(child, word, index + 1);

			if (!child.Children.Any() && !child.IsEndOfWord) root.Children.Remove(ch);
		}

		public IList<string> FindWords(string prefix)
		{
			var list = new List<string>();
			var node = FindLastNodeOf(prefix);
			FindWords(node, prefix, list);
			return list;
		}

		private void FindWords(Node root, string prefix, IList<string> words)
		{
			if (root == null) return;
			if (root.IsEndOfWord) words.Add(prefix);
			foreach (var child in root.GetChildren())
				FindWords(child, $"{prefix}{child}", words);
		}

		private Node FindLastNodeOf(string prefix)
		{
			if (prefix == null) return null;
			var current = Root;
			foreach(var ch in prefix.ToCharArray())
			{
				if (!current.Children.ContainsKey(ch))
					return null;
				current = current.Children[ch];
			}
			return current;
		}
	}
}
