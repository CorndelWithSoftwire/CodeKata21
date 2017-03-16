using System;
using System.Collections.Generic;
using System.Linq;
using CodeKata21.Interface;

namespace CodeKata21.Implementation
{
  public class SinglyLinkedList : ISimpleList
  {
    private readonly ListNode head = new HeadNode();

    private class ListNode : IListNode
    {
      public string Value { get; set; }

      public ListNode Next { get; set; }
    }

    private class HeadNode : ListNode
    {
    }

    public void Add(string value)
    {
      var newTail = new ListNode {Value = value};
      Nodes.Last().Next = newTail;
    }

    public IListNode Find(string value)
    {
      return Nodes.Skip(1).FirstOrDefault(node => node.Value == value);
    }

    public void Delete(IListNode nodeToDelete)
    {
      var previousNode = Nodes.FirstOrDefault(node => node.Next == nodeToDelete);

      if (previousNode == null)
      {
        throw new InvalidOperationException("Node not found in the list");
      }

      previousNode.Next = ((ListNode) nodeToDelete).Next;
    }

    public string[] Values => Nodes.Skip(1).Select(node => node.Value).ToArray();

    private IEnumerable<ListNode> Nodes
    {
      get
      {
        var currentNode = head;

        while (currentNode != null)
        {
          yield return currentNode;
          currentNode = currentNode.Next;
        }
      }
    }
  }
}