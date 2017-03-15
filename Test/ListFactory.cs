using CodeKata21.Interface;

namespace CodeKata21.Test
{
  public interface IListFactory
  {
    ISimpleList Create();
  }

  public class ListFactory<TList> : IListFactory where TList : ISimpleList, new()
  {
    public ISimpleList Create()
    {
      return new TList();
    }

    public override string ToString()
    {
      return typeof(TList).Name;
    }
  }
}