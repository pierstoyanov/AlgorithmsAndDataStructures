using System;
using System.Collections.Generic;


namespace DataStructuresLib 
{
    public class MaxPriorityQueue<T>
    {
        private List<(T element, int priority)> heap;

        public MaxPriorityQueue()
        {
            heap = new List<(T, int)>();
        }

        public MaxPriorityQueue(T element, int priority)
        {
            heap = new List<(T, int)>();
            Enqueue(element, priority);
        }

        public int Count
        {
            get { return heap.Count; }
        }

        private int Parent(int idx)
        {
            return (idx - 1) / 2;
        }

        private int Left(int idx)
        {
            return 2 * idx + 1;
        }

        private int Right(int idx)
        {
            return (2 * idx) + 2;
        }

        public void Enqueue(T element, int priority)
        {
            var currentIdx = Count;
            heap.Add((element, priority));

            while (currentIdx != 0 &&
                heap[currentIdx].priority > heap[Parent(currentIdx)].priority)
            {
                Swap(currentIdx, Parent(currentIdx));
                currentIdx = Parent(currentIdx);
            }
        }

        public T Dequeue()
        {
            ValidateNotEmpty();

            if (Count == 1)
            {
                var result = heap[0];
                heap.RemoveAt(0);
                return result.element;
            }

            var root = heap[0];

            heap[0] = heap[Count - 1];
            heap.RemoveAt(Count - 1);

            HeapifyDown(0);

            return root.element;
        }

        private void HeapifyDown(int idx)
        {
            int left = Left(idx);
            int right = Right(idx);
            int biggest = idx;

            if (left < Count && heap[left].priority > heap[biggest].priority)
            {
                biggest = left;
            }

            if (right < Count  && heap[right].priority > heap[biggest].priority)
            {
                biggest = right;
            }

            if (biggest != idx)
            {
                Swap(idx, biggest);
                HeapifyDown(biggest);
            }
        }

        public T Peek()
        {
            ValidateNotEmpty();
            return heap[0].element;
        }

        private void Swap(int indexOne, int indexTwo)
        {
            ValidateIndex(indexOne, indexTwo);

            (T, int) temp = heap[indexOne];
            heap[indexOne] = heap[indexTwo];
            heap[indexTwo] = temp;
        }

        private void ValidateNotEmpty()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Queue is empty!");
        }

        private void ValidateIndex(params int[] indexes)
        {
            foreach (int index in indexes)
            {
                if (index < 0 || index > heap.Count - 1)
                    throw new InvalidOperationException();
            }
        }

        public bool checkMaxHeap()
        {
            if (heap.Count <= 1)
            {
                return true;
            }

            for (int i = 0; i <= (heap.Count - 2) / 2; i++)
            {
                // check if node has higher priority than left child
                if (heap[i].priority < heap[Left(i)].priority)
                {
                    return false;
                }

                // check if node has higher priority than right child and right child exists
                if (Right(i) != heap.Count && 
                    heap[i].priority < heap[Right(i)].priority)
                {
                    return false;
                }
            }

            return true;
        }
    }
}