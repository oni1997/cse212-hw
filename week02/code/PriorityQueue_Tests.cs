using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them.
    // Expected Result: Items are dequeued in order of highest priority first.
    // Defect(s) Found: Test PASSED. Actual dequeue order: B (priority 3), C (priority 2), A (priority 1)
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
    // Defect(s) Found: Test PASSED. Actual dequeue order: A, B, C (FIFO order maintained for equal priority 2)
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

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: Test PASSED. InvalidOperationException thrown with correct message: "The queue is empty."
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                               e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities and verify FIFO for equal priorities
    // Expected Result: Higher priority items come first, equal priority items follow FIFO order
    // Defect(s) Found: Test PASSED. Actual dequeue order: High1, High2, Medium1, Medium2, First, Low (priority order with FIFO for equal priorities)
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("High1", 5);
        priorityQueue.Enqueue("Medium1", 3);
        priorityQueue.Enqueue("High2", 5);
        priorityQueue.Enqueue("Medium2", 3);
        priorityQueue.Enqueue("Low", 1);

        // Should dequeue in order: High1, High2, Medium1, Medium2, First, Low
        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        Assert.AreEqual("Medium1", priorityQueue.Dequeue());
        Assert.AreEqual("Medium2", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue single item and dequeue it
    // Expected Result: The single item is returned correctly
    // Defect(s) Found: Test PASSED. Single item "OnlyItem" with priority 10 was correctly dequeued
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("OnlyItem", 10);
        Assert.AreEqual("OnlyItem", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items, dequeue some, then enqueue more
    // Expected Result: New items are properly prioritized with existing items
    // Defect(s) Found: Test PASSED. Actual dequeue order: A (priority 2), C (priority 3), B (priority 1), D (priority 1) - correct priority and FIFO ordering
    public void TestPriorityQueue_InterleavedOperations()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue()); // Highest priority first

        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 1);

        Assert.AreEqual("C", priorityQueue.Dequeue()); // Highest priority (3)
        Assert.AreEqual("B", priorityQueue.Dequeue()); // First of equal priority (1)
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Second of equal priority (1)
    }

    // Add more test cases as needed below.
}