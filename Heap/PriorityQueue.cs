namespace DataStructures.Heap
{
	public class PriorityQueue : Heap
	{
		public PriorityQueue(int size) : base(size) { }

		public void Enqueue(int item) => Insert(item);

		public void Dequeue(int item) => Remove();
	}
}
