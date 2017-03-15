namespace CodeKata21.Interface
{
  public interface ISimpleList
  {
    void Add(string value);

    IListNode Find(string value);

    void Delete(IListNode node);

    string[] Values { get; }
  }
}