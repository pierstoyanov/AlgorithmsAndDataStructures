using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresLib
{
    class MinMaxHeap<T>
        where T : IComparable
    {
        private List<T> heap;

        private int indicator;

        public int Size { get { return heap.Count; } }

        public MinMaxHeap()
        {
            heap = new List<T>();
            indicator = 1;
        }

        public void Add(T item)
        {
            if (!heap.Any())
            {
                heap.Add(item);
                indicator++;
            }
            else
            {
                heap.Add(item);
                PushUp(heap, indicator);
                indicator++;
            }
        }

        private void PushUp(List<T> heap, int i)
        {
            if (i != 1)
            {   
                //even level
                if (i % 2 == 0)
                {
                    if (heap[i - 1].CompareTo(heap[GetParentIndex(i) - 1]) < 0)
                    {
                        PushUpMin(heap, i);
                    }
                    else
                    {
                        Swap(i - 1, GetParentIndex(i) - 1, heap);
                        i = GetParentIndex(i);
                        PushUpMax(heap, i);
                    }
                }
                else if (heap[i - 1].CompareTo(heap[GetParentIndex(i) - 1]) > 0)
                {
                    PushUpMax(heap, i);
                }
                else
                {
                    Swap(i - 1, GetParentIndex(i) - 1, heap);
                    i = GetParentIndex(i);
                    PushUpMin(heap, i);
                }
            }
        }

        private void PushUpMax(List<T> heap, int i)
        {
            while (hasGrandparent(i) &&
                heap[i - 1].CompareTo(heap[GetGrandParentIndex(i) - 1]) > 0)
            {
                Swap(i - 1, GetGrandParentIndex(i) - 1, heap);
                i = GetGrandParentIndex(i);
            }
        }

        private void PushUpMin(List<T> heap, int i)
        {
            while(hasGrandparent(i) && 
                heap[i - 1].CompareTo(heap[GetGrandParentIndex(i) - 1]) < 0)
            {
                Swap(i - 1, GetGrandParentIndex(i) - 1, heap);
                i = GetGrandParentIndex(i);
            }
        }

        private bool hasGrandparent(int i)
        {
            var grandParentIdx = GetParentIndex(i);
            return grandParentIdx > 0 && grandParentIdx < heap.Count;
        }

        private void Swap(int v1, int v2, List<T> heap)
        {
            var temp = heap[v1];
            heap[v1] = heap[v2];
            heap[v2] = temp;
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

        private int GetLeftChildIndex(int i)
        {
            return 2 * i;
        }

        private int GetRightChildIndex(int i)
        {
            return (2 * i) + 1;
        }
        private int GetParentIndex(int i)
        {
            return i / 2;
        }
        private int GetGrandParentIndex(int i)
        {
            return i / 4;
        }

        public T Min()
        {
            if (heap.Any())
            {
                return heap[0];
            }
            return default;
        }

        public T Max()
        {
            if (heap.Any())
            {
                if (indicator == 2)
                {
                    return heap[0];
                }

                if (indicator == 3)
                {
                    return heap[1];
                }
                return heap[1].CompareTo(heap[2]) < 0 ? heap[2] : heap[1];
            }
           return default;
        }
    }
}
