using System;
using System.Collections.Generic;
using System.Linq;
using CodeKata21.Interface;

namespace CodeKata21.Implementation
{
  public class SinglyLinkedList : ISimpleList
  {
    private ListNode head;
    private ListNode tail;

    private class ListNode : IListNode
    {
      public string Value { get; set; }

      public ListNode Next { get; set; }
    }

    public void Add(string value)
    {
      var newTail = new ListNode {Value = value};

      if (tail == null)
      {
        head = newTail;
      }
      else
      {
        tail.Next = newTail;
      }

      tail = newTail;
    }

    public IListNode Find(string value)
    {
      ListNode searchNode = head;

      while (searchNode != null)
      {
        if (searchNode.Value == value)
        {
          return searchNode;
        }

        searchNode = searchNode.Next;
      }

      return null;
    }

    public void Delete(IListNode node)
    {
      if (!(node is ListNode))
      {
        throw new ArgumentException("Cannot delete a node from another type of list", nameof(node));
      }
      
      if (node == head)
      {
        head = head.Next;

        if (head == null) tail = null;

        return;
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
        var currentNode = head;

        while (currentNode != null)
        {
          yield return currentNode.Value;
          currentNode = currentNode.Next;
        }
      }
    }
  }
}