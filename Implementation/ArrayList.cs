using System;
using System.Linq;
using CodeKata21.Interface;

namespace CodeKata21.Implementation
{
  public class ArrayList : ISimpleList
  {
    private static int DefaultCapacity = 1;
    private IListNode[] array = new IListNode[DefaultCapacity];
    private int length;

    private class ListNode : IListNode
    {
      public string Value { get; set; }
    }

    public void Add(string value)
    {
      if (length == array.Length)
      {
        ExpandArray();
      }

      array[length] = new ListNode {Value = value};
      length++;
    }

    private void ExpandArray()
    {
      var newArray = new IListNode[array.Length * 2];
      Array.Copy(array, newArray, array.Length);
      array = newArray;
    }

    public IListNode Find(string value)
    {
      return array.Take(length).FirstOrDefault(node => node.Value == value);
    }

    public void Delete(IListNode node)
    {
      int position = Array.IndexOf(array, node);

      if (position < 0)
      {
        throw new InvalidOperationException("Node not found in the list");
      }

      for (int i = position; i < length - 1; i++)
      {
        array[i] = array[i + 1];
      }

      length--;
    }

    public string[] Values => array.Take(length).Select(node => node.Value).ToArray();
  }
}