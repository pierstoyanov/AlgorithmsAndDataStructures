using DataStructuresLib;

namespace DataStructuresTests
{
    public class PriorityQueueTests
    {
        [SetUp]
        public void Setup()
        {
            var pq = new CustomPriorityQueue<int>();
        }

        [Test]
        public void EnqueueTest()
        {
            Assert.Pass();
        }
    }
}