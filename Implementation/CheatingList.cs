using System.Collections.Generic;
using System.Linq;
using CodeKata21.Interface;

namespace CodeKata21.Implementation
{
  // This is an implementation of ISimpleList using the C# built-in list class
  public class CheatingList : ISimpleList
  {
    private readonly IList<ListNode> list = new List<ListNode>();

    private class ListNode : IListNode
    {
      public ListNode(string value)
      {
        Value = value;
      }

      public string Value { get; }
    }

    public void Add(string value)
    {
      list.Add(new ListNode(value));
    }

    public IListNode Find(string value)
    {
      return list.FirstOrDefault(node => node.Value == value);
    }

    public void Delete(IListNode node)
    {
      if (!(node is ListNode))
      {
        throw new System.ArgumentException("Cannot delete a node from another type of list", nameof(node));
      }

      list.Remove((ListNode) node);
    }

    public string[] Values => list.Select(node => node.Value).ToArray();
  }
}