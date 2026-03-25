using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities and remove one
    // Expected Result: Item with the highest priority should be removed first
    // Defect(s) Found: Initially, the queue did not always return the highest priority item correctly.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("B", result); // highest priority
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority
    // Expected Result: The item that was added first (FIFO) should be removed first
    // Defect(s) Found: Queue did not follow FIFO order when priorities were equal.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("A", result); // first inserted with highest priority
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Exception should be thrown with correct message
    // Defect(s) Found: Exception was not thrown or message was incorrect.
    public void TestPriorityQueue_Empty()
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
    // Scenario: Add and remove multiple items to ensure queue continues working correctly
    // Expected Result: Items should always be removed based on highest priority
    // Defect(s) Found: Some items were not removed in correct priority order.
    public void TestPriorityQueue_MultipleOperations()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 4);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }
}