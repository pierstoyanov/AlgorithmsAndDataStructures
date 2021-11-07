using System;
using System.Collections.Generic;

namespace DataStructuresLib
{
    class MinHeap<T>
        where T : IComparable
    {
        private List<T> heap;

        public int Size { get { return heap.Count; } }

        public MinHeap()
        {
            heap = new List<T>();
        }

        public void Add(T item)
        {
            heap.Add(item);
            Heapify(heap.Count - 1);
        }

        private void Heapify(int index)
        {
            //base case
            if (index == 0) return;

            //parent
            int parentIndex = (index - 1) / 2;
            //swap if bigger than parent
            if (heap[index].CompareTo(heap[parentIndex]) < 0)
            {
                T temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;
                //recursively call for each new place
                Heapify(parentIndex);
            }
        }

        public T GetMin()
        {
            VerifyNotEmpty();
            return this.heap[0];
        }

        public T Peek()
        {
            VerifyNotEmpty();
            return GetMin();
        }

        private void VerifyNotEmpty()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");
        }

        public string PrintDFSInOrder(int index, int indent)
        {
            string result = "";
            int leftChild = 2 * index + 1;
            int rightChild = 2 * indent + 2;

            if (leftChild < heap.Count)
            {
                result += PrintDFSInOrder(leftChild, indent + 2);
            }

            result += $"{new string(' ', indent)}{heap[index]}\r\n";

            if (rightChild < heap.Count)
            {
                result += PrintDFSInOrder(rightChild, indent + 2);
            }

            return result;
        }
    }
}
