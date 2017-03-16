using System;
using System.Collections.Generic;
using System.Linq;
using CodeKata21.Interface;

namespace CodeKata21.Implementation
{
  public class SinglyLinkedList : ISimpleList
  {
    private readonly ListNode head = new HeadNode();
    private ListNode tail;

    private class ListNode : IListNode
    {
      public string Value { get; set; }

      public ListNode Next { get; set; }
    }

    private class HeadNode : ListNode
    {
    }

    public SinglyLinkedList()
    {
      tail = head;
    }

    public void Add(string value)
    {
      var newTail = new ListNode {Value = value};
      tail.Next = newTail;
      tail = newTail;
    }

    public IListNode Find(string value)
    {
      foreach (var searchNode in Nodes.Skip(1))
      {
        if (searchNode.Value == value)
        {
          return searchNode;
        }
      }

      return null;
    }

    public void Delete(IListNode node)
    {
      foreach (var searchNode in Nodes)
      {
        if (searchNode.Next == node)
        {
          searchNode.Next = ((ListNode)node).Next;

          if (node == tail)
          {
            tail = searchNode;
          }

          return;
        }
      }

      throw new InvalidOperationException("Node not found in the list");
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