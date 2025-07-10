using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them.
    // Expected Result: Items are dequeued in order of highest priority first.
    // Defect(s) Found: Implementation does not remove the dequeued item; also, loop is off by one.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        Assert.AreEqual("B", priorityQueue.Dequeue()); // Highest priority
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Next highest
        Assert.AreEqual("A", priorityQueue.Dequeue()); // Lowest
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority and dequeue them.
    // Expected Result: Items are dequeued in FIFO order when priorities are equal.
    // Defect(s) Found: Implementation does not remove the dequeued item; also, loop is off by one.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}