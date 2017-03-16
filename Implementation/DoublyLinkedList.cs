using System;
using System.Collections.Generic;
using System.Linq;
using CodeKata21.Interface;

namespace CodeKata21.Implementation
{
  public class DoublyLinkedList : ISimpleList
  {
    private readonly ListNode headAndTail = new ListNode();

    private class ListNode : IListNode
    {
      public string Value { get; set;  }

      public ListNode Prev { get; set; }

      public ListNode Next { get; set; }
    }

    public DoublyLinkedList()
    {
      headAndTail.Prev = headAndTail;
      headAndTail.Next = headAndTail;
    }

    public void Add(string value)
    {
      var oldTail = headAndTail.Prev;
      var newTail = new ListNode { Value = value, Prev = oldTail, Next = headAndTail };
      oldTail.Next = newTail;
      headAndTail.Prev = newTail;
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

      previousNode.Next = ((ListNode)nodeToDelete).Next;
      previousNode.Next.Prev = previousNode;
    }

    public string[] Values => Nodes.Skip(1).Select(node => node.Value).ToArray();

    private IEnumerable<ListNode> Nodes
    {
      get
      {
        var currentNode = headAndTail;

        do
        {
          yield return currentNode;
          currentNode = currentNode.Next;
        } while (currentNode != headAndTail);
      }
    }
  }
}