using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
	public class Heap
	{
		private int[] items;
		private int size;

		public Heap(int size)
		{
			items = new int[size];
		}

		public int Remove()
		{
			if (IsEmpty()) return -1;

			var root = items[0];
			items[0] = items[--size];
			BubbleDown();
			return root;
		}

		private void BubbleDown()
		{
			var index = 0;
			while (index <= size && !IsValidParent(index))
			{
				var largerChildIndex = LargerChildIndex(index);
				Swap(index, largerChildIndex);
				index = largerChildIndex;
			}
		}

		private bool IsEmpty()
		{
			return size == 0;
		}

		private int LargerChildIndex(int index)
		{
			if (!HasLeftChild(index)) return index;

			if (!HasRightChild(index)) return LeftChildIndex(index);

			return LeftChild(index) > RightChild(index) ?
					LeftChildIndex(index) : RightChildIndex(index);
		}

		private bool HasLeftChild(int index)
		{
			return LeftChildIndex(index) <= size;
		}

		private bool HasRightChild(int index)
		{
			return RightChildIndex(index) <= size;
		}

		private bool IsValidParent(int index)
		{
			if (!HasLeftChild(index)) return true;

			var isValid = items[index] >= LeftChild(index);

			if (HasRightChild(index))
				isValid &= items[index] >= RightChild(index);

			return isValid;
		}

		private int RightChild(int index)
		{
			return items[RightChildIndex(index)];
		}

		private int LeftChild(int index)
		{
			return items[LeftChildIndex(index)];
		}

		private int LeftChildIndex(int index)
		{
			return index * 2 + 1;
		}

		private int RightChildIndex(int index)
		{
			return index * 2 + 2;
		}

		public void Insert(int item)
		{
			if (IsFull()) return;
			items[size++] = item;
			BubbleUp();
		}

		private bool IsFull()
		{
			return size == items.Length;
		}

		private void BubbleUp()
		{
			var index = size - 1;
			while(index > 0 && items[index] > items[Parent(index)])
			{
				Swap(index, Parent(index));
				index = Parent(index);
			}
		}

		private int Parent(int index)
		{
			return (index - 1) / 2;
		}

		private void Swap(int index1, int index2)
		{
			var temp = items[index1];
			items[index1] = items[index2];
			items[index2] = temp;
		}
	}
}
