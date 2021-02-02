namespace DataStructures.Heap
{
	public class MaxHeap
	{
		public static void Heapify(int[] array)
		{
			var lastParentIndex = array.Length / 2;
			for (int i = lastParentIndex; i >= 0; i--)
				Heapify(array, i);
		}

		private static void Heapify(int[] array, int index)
		{
			var largerIndex = index;

			var leftIndex = index * 2 + 1;
			if (leftIndex < array.Length && array[leftIndex] > array[largerIndex])
				largerIndex = leftIndex;

			var rightIndex = index * 2 + 2;
			if (rightIndex < array.Length && array[rightIndex] > array[largerIndex])
				largerIndex = rightIndex;

			if (index == largerIndex) return;

			Swap(array, index, largerIndex);
			Heapify(array, largerIndex);
		}

		private static void Swap(int[] array, int index, int largerIndex)
		{
			var temp = array[index];
			array[index] = array[largerIndex];
			array[largerIndex] = temp;
		}

		public static int GetKthLargest(int[] array, int k)
		{
			var heap = new Heap(array.Length);
			foreach (var item in array)
				heap.Insert(item);

			for (int i = 0; i < k - 1; i++)
				heap.Remove();

			return heap.Remove();
		}
	}
}
