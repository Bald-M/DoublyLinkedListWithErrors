using DoublyLinkedListWithErrors;
using System.Security.Cryptography;

namespace DoublyLinkedListTestMethods
{
  [TestClass]
  public class UnitTest1
  {

    // Test adding nodes to the tail
    [TestMethod]
    public void TestMethod1_AddToTail()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(5);
      DLLNode node2 = new DLLNode(3);

      list.addToTail(node1);
      list.addToTail(node2);

      Assert.AreEqual(list.head, node1);
      Assert.AreEqual(list.tail, node2);
      Assert.AreEqual(node1.next, node2);
      Assert.AreEqual(node2.previous, node1);
    }

    // Test adding nodes to the head
    [TestMethod]
    public void TestMethod2_AddToHead()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(5);
      DLLNode node2 = new DLLNode(3);

      list.addToHead(node1);
      list.addToHead(node2);

      Assert.AreEqual(list.head, node2);
      Assert.AreEqual(list.tail, node1);
      Assert.AreEqual(node1.previous, node2);
      Assert.AreEqual(node2.next, node1);
    }

    // Test removing the head
    [TestMethod]
    public void TestMethod3_RemoveHead()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(5);

      list.addToHead(node1);
      list.removHead();

      Assert.IsNull(list.head);
      Assert.IsNull(list.tail);
    }

    // Test search a node
    [TestMethod]
    public void TestMethod4_SearchNode()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(5);

      list.addToHead(node1);
      list.removeTail();

      Assert.IsNull(list.head);
      Assert.IsNull(list.tail);
    }

    // Test Removing the tail
    [TestMethod]
    public void TestMethod5_RemoveTail()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(5);
      DLLNode node2 = new DLLNode(3);
      DLLNode node3 = new DLLNode(8);
      DLLNode node4 = new DLLNode(2);
      list.addToTail(node1);
      list.addToTail(node2);
      list.addToTail(node3);
      list.addToTail(node4);

      DLLNode foundNode = list.search(8);

      Assert.AreEqual(foundNode, node3);
    }

    // Test remove a specific node
    [TestMethod]
    public void TestMethod6_RemoveSpecificNode()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(5);

      list.addToTail(node1);
      list.removeNode(node1);

      Assert.IsNull(list.head);
      Assert.IsNull(list.tail);
    }

    // Test the total method
    [TestMethod]
    public void TestMethod7_Total()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(5);
      DLLNode node2 = new DLLNode(3);

      list.addToTail(node1);
      list.addToTail(node2);

      int total = list.total();

      Assert.AreEqual(total, 8);
    }

    // Test the isPrime method
    [TestMethod]
    public void TestMethod8_IsPrime()
    {
      DLLNode node = new DLLNode(3);
      Assert.IsTrue(node.isPrime(3));
    }

    // Test the isPrime method with negative number
    [TestMethod]
    public void TestMethod9_IsPrimeWithNegative()
    {
      DLLNode node = new DLLNode(-3);
      Assert.IsFalse(node.isPrime(-3));
    }

    // Test the isPrime method with number 0
    [TestMethod]
    public void TestMethod10_IsPrimeWithZero()
    {
      DLLNode node = new DLLNode(0);
      Assert.IsFalse(node.isPrime(0));
    }

    // Test the search method
    [TestMethod]
    public void TestMethod11_Search()
    {
      DLList list = new DLList();

      list.addToHead(new DLLNode(5));

      DLLNode targetNode = list.search(5);
      Assert.IsNotNull(targetNode);
      Assert.AreEqual(5, targetNode.num);
    }

    // Test search node from the empty list
    [TestMethod]
    public void TestMethod12_SearchEmptyList()
    {
      DLList list = new DLList();
      DLLNode targetNode = list.search(5);
      Assert.IsNull(targetNode);
    }

    // Test search a non-existing node in the list
    [TestMethod]
    public void TestMethod13_SearchNonExisting()
    {
      DLList list = new DLList();
      list.addToHead(new DLLNode(5));
      DLLNode targetNode = list.search(3);
      Assert.IsNull(targetNode);
    }

    // Test search for node in a list that has multiple nodes
    [TestMethod]
    public void TestMethod14_SearchInMultiple()
    {
      DLList list = new DLList();
      list.addToHead(new DLLNode(6));
      list.addToHead(new DLLNode(3));
      list.addToHead(new DLLNode(7));
      DLLNode targetNode = list.search(3);
      Assert.IsNotNull(targetNode);
      Assert.AreEqual(3, targetNode.num);
    }

    // Test adding and removing multiple nodes
    [TestMethod]
    public void TestMethod15_AddRemoveMultipleNodes()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(5);
      DLLNode node2 = new DLLNode(3);

      list.addToTail(node1);
      list.addToTail(node2);

      list.removeNode(node2);

      Assert.AreEqual(list.head, node1);
      Assert.IsNull(node1.next);

    }

    // Test adding and removing nodes with non-prime numbers
    [TestMethod]
    public void TestMethod16_AddRemoveNonPrimeNumbers()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(4);
      DLLNode node2 = new DLLNode(6);
      DLLNode node3 = new DLLNode(9);

      list.addToTail(node1);
      list.addToTail(node2);
      list.addToTail(node3);

      list.removeNode(node2);
      
      Assert.AreEqual(list.head, node1);
      Assert.AreEqual(list.tail, node3);
      Assert.AreNotEqual(node2, node1.next);
      Assert.AreEqual(node1.next, node3);
      Assert.AreEqual(node3.previous, node1);
      
    }


    // Test the behavior of methods when the list has only one node
    [TestMethod]
    public void TestMethod17_SingleNodeListBehavior()
    {
      DLList list = new DLList();
      DLLNode node = new DLLNode(5);
      list.addToTail(node);

      list.removeNode(node);

      Assert.IsNull(list.head);
      Assert.IsNull(list.tail);
      Assert.IsNull(node.next);
      Assert.IsNull(node.previous);
    }

    // Test adding and removing nodes with null references
    [TestMethod]
    public void TestMethod18_AddRemoveNullNodes()
    {
      DLList list = new DLList();
      DLLNode node1 = null;
      DLLNode node2 = new DLLNode(5);

      list.addToTail(node1);
      list.addToTail(node2);

      Assert.AreEqual(list.head, node2);
      Assert.AreEqual(list.tail, node2);
      Assert.IsNull(node2.previous);
      Assert.IsNull(node2.next);

      list.removeNode(node1);

      Assert.AreEqual(list.head, node2);
      Assert.AreEqual(list.tail, node2);
      Assert.IsNull(node2.previous);
      Assert.IsNull(node2.next);
    }

    // Test adding and removing nodes in alternating order (head, tail, head, tail)
    [TestMethod]
    public void TestMethod19_AddRemoveAlternatingOrder()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(5);
      DLLNode node2 = new DLLNode(3);
      DLLNode node3 = new DLLNode(8);
      DLLNode node4 = new DLLNode(2);

      list.addToHead(node1);
      list.addToTail(node2);
      list.addToHead(node3);
      list.addToTail(node4);

      list.removeNode(node1);
      list.removeNode(node2);
      list.removeNode(node3);
      list.removeNode(node4);

      Assert.IsNull(list.head);
      Assert.IsNull(list.tail);
    }

    // Test adding and removing nodes when the list is already sorted
    [TestMethod]
    public void TestMethod20_AddRemoveSortedOrder()
    {
      DLList list = new DLList();
      DLLNode node1 = new DLLNode(1);
      DLLNode node2 = new DLLNode(3);
      DLLNode node3 = new DLLNode(5);

      list.addToTail(node1);
      list.addToTail(node2);
      list.addToTail(node3);

      list.removeNode(node1);
      list.removeNode(node2);
      list.removeNode(node3);

      Assert.IsNull(list.head);
      Assert.IsNull(list.tail);
    }

  }
}