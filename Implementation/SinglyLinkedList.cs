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
      ListNode searchNode = head;

      while ((searchNode = searchNode.Next) != null)
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
      if (!(node is ListNode))
      {
        throw new ArgumentException("Cannot delete a node from another type of list", nameof(node));
      }

      if (node is HeadNode)
      {
        // This should not be possible as we never return the HeadNode to the caller
        throw new ArgumentException("Cannot delete the head of a list", nameof(node));
      }
      
      var deleteNode = (ListNode) node;
      ListNode searchNode = head;

      while (searchNode != null)
      {
        if (searchNode.Next == deleteNode)
        {
          searchNode.Next = deleteNode.Next;

          if (deleteNode == tail)
          {
            tail = searchNode;
          }

          return;
        }

        searchNode = searchNode.Next;
      }

      throw new InvalidOperationException("Node not found in the list");
    }

    public string[] Values => ValueEnumerable.ToArray();

    private IEnumerable<string> ValueEnumerable
    {
      get
      {
        var currentNode = head.Next;

        while (currentNode != null)
        {
          yield return currentNode.Value;
          currentNode = currentNode.Next;
        }
      }
    }
  }
}