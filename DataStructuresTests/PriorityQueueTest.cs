using NUnit.Framework;
using DataStructuresLib;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresTests
{
    public class PriorityQueueTests
    {
        private class Item
        {
            public int Value { get; set; }
         
            public Item(int p)
            {
                this.Value = p;
            }
        }

        private List<Item> items;
        private CustomPriorityQueue<Item> pq;
        private List<int> priorities;

        [SetUp]
        public void Setup()
        {
            pq = new CustomPriorityQueue<Item>();
            priorities = new List<int> { 1, 5, 14, 18, 23, 58, 45 };

            items = new List<Item>();
            foreach (var p in priorities)
            {
                items.Add(new Item(p));
            }
        }

        [TearDown]
        public void TestCleanup()
        {
            pq = new CustomPriorityQueue<Item>();
        }

        [Test]
        public void EnqueueDequeueTest()
        {
            var testPriorities = new int[] { 15, 1, 10, 14, 13, 10, 9, 85, 108, 45, 50 };
            var sorted = testPriorities.OrderBy(i => i);
            foreach (var el in testPriorities)
            {
                pq.Enqueue(new Item(el), el);
            }

            Assert.Multiple(() =>
            {
                foreach (var s in sorted)
                {
                    Assert.That(pq.Dequeue().Value, Is.EqualTo(s));
                }
                /*Assert.That(pq.Dequeue().Value, Is.EqualTo(1));
                Assert.That(pq.Dequeue().Value, Is.EqualTo(10));
                Assert.That(pq.Dequeue().Value, Is.EqualTo(15));*/
            });
        }

        [Test]
        public void HeapPropertyTest()
        {
            foreach (var i in items)
            {
                pq.Enqueue(i, i.Value);
            }

            var isHeap = pq.checkMinHeap();
            Assert.That(isHeap, Is.True);
        }

        [Test]
        public void PeekTest()
        {
            foreach (var i in items)
            {
                pq.Enqueue(i, i.Value);
            }

            var countBefore = pq.Count;
            var peek = pq.Peek();

            Assert.Multiple(() =>
            {
                Assert.That(pq.Count, Is.EqualTo(countBefore));
                Assert.That(pq.Dequeue(), Is.EqualTo(peek));
            });
        }
    }
}