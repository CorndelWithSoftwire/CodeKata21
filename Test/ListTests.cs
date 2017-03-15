using CodeKata21.Implementation;
using NUnit.Framework;

namespace CodeKata21.Test
{
  [TestFixture]
  public class ListTests
  {
    private static IListFactory[] ListImplementations => new IListFactory[]
    {
      new ListFactory<CheatingList>()
    };

    [Test]
    [TestCaseSource(nameof(ListImplementations))]
    public void AddingItemsToTheList(IListFactory listFactory)
    {
      /* Translated from:
            list = List.new
            assert_nil(list.find("fred"))
            list.add("fred")
            assert_equal("fred", list.find("fred").value())
            assert_nil(list.find("wilma"))
            list.add("wilma")
            assert_equal("fred",  list.find("fred").value())
            assert_equal("wilma", list.find("wilma").value())
            assert_equal(["fred", "wilma"], list.values())

        It would be cleaner to write separate Arrange-Act-Assert tests for each part of this!*/

      var list = listFactory.Create();
      Assert.IsNull(list.Find("fred"));
      list.Add("fred");
      Assert.AreEqual("fred", list.Find("fred").Value);
      Assert.IsNull(list.Find("wilma"));
      list.Add("wilma");
      Assert.AreEqual("fred", list.Find("fred").Value);
      Assert.AreEqual("wilma", list.Find("wilma").Value);
      CollectionAssert.AreEqual(new[] {"fred", "wilma"}, list.Values);
    }

    [Test]
    [TestCaseSource(nameof(ListImplementations))]
    public void DeletingItemsFromTheList(IListFactory listFactory)
    {
      /* Translated from:
            list = List.new
            list.add("fred")
            list.add("wilma")
            list.add("betty")
            list.add("barney")
            assert_equal(["fred", "wilma", "betty", "barney"], list.values())
            list.delete(list.find("wilma"))
            assert_equal(["fred", "betty", "barney"], list.values())
            list.delete(list.find("barney"))
            assert_equal(["fred", "betty"], list.values())
            list.delete(list.find("fred"))
            assert_equal(["betty"], list.values())
            list.delete(list.find("betty"))
            assert_equal([], list.values())

        It would be cleaner to write separate Arrange-Act-Assert tests for each part of this!*/

      var list = listFactory.Create();
      list.Add("fred");
      list.Add("wilma");
      list.Add("betty");
      list.Add("barney");
      CollectionAssert.AreEqual(new[] {"fred", "wilma", "betty", "barney"}, list.Values);
      list.Delete(list.Find("wilma"));
      CollectionAssert.AreEqual(new[] {"fred", "betty", "barney"}, list.Values);
      list.Delete(list.Find("barney"));
      CollectionAssert.AreEqual(new[] {"fred", "betty"}, list.Values);
      list.Delete(list.Find("fred"));
      CollectionAssert.AreEqual(new[] {"betty"}, list.Values);
      list.Delete(list.Find("betty"));
      CollectionAssert.AreEqual(new string[0], list.Values);
    }
  }
}