using System;
using System.Collections.Generic;


public class CustomPriorityQueue<T>
{
    private List<(T, int)> heap;

    public CustomPriorityQueue()
    {
        // (element - T, priority int)
        heap = new List<(T, int)>();
    }

    public CustomPriorityQueue(T element, int priority)
    {
        heap = new List<(T, int)>();
        Enqueue(element, priority);
    }

    public int Count
    {
        get { return heap.Count; }
    }

    public void Enqueue(T element, int priority)
    {
        heap.Add((element, priority));
        Heapify(heap.Count - 1);
    }

    public T Dequeue()
    {
        ValidateNotEmpty();

        //take first element
        (T, int) result = heap[0];

        //swap first and last element & remove last
        Swap(0, Count - 1);
        heap.RemoveAt(Count - 1);

        HeapifyDown(0);

        return result.Item1;
    }

    private void Heapify(int index)
    {
        if (index == 0)
            return;

        int parentIndex = (index - 1) / 2;

        if (heap[index].Item2 < heap[parentIndex].Item2)
        {
            //heap[index], heap[parentIndex] = heap[parentIndex], heap[index];
            Swap(index, parentIndex);
            Heapify(parentIndex);
        }
    }

    private void HeapifyDown(int index)
    {
        int leftChildIndex = 2 * index + 1;
        int rightChildIndex = 2 * index + 2;
        int maxChildIndex = leftChildIndex;

        if (leftChildIndex >= heap.Count)
            return;

        if (rightChildIndex > heap.Count && heap[leftChildIndex].Item2 > heap[rightChildIndex].Item2)
        {
            maxChildIndex = rightChildIndex;
        }

        if (heap[index].Item2 > heap[maxChildIndex].Item2)
        {
            Swap(index, maxChildIndex);
            HeapifyDown(maxChildIndex);
        }
    }

    public T Peek()
    {
        ValidateNotEmpty();
        return heap[0].Item1;
    }

    private void Swap(int indexOne, int indexTwo)
    {
        ValidateIndex(indexOne, indexTwo);
        // Swap items at index One and index Two
        (T, int) temp = heap[indexOne];
        heap[indexOne] = heap[indexTwo];
        heap[indexTwo] = temp;
    }

    private void ValidateNotEmpty()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException();
    }

    private void ValidateIndex(params int[] indexes)
    {
        foreach (int index in indexes)
        {
            if (index < 0 || index > heap.Count - 1)
                throw new InvalidOperationException();
        }
    }
}