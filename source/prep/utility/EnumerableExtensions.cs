using System.Collections.Generic;
using prep.collections;
using prep.utility.searching;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (var item in items) yield return item;
    }

    static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Criteria<T> criteria)
    {
      foreach (var item in items)
        if (criteria(item)) yield return item;
    }

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, IMatchA<T> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }



    public static ItemsToMatch<ItemToBuildSpecificationOn, AttributeType>
      where<ItemToBuildSpecificationOn, AttributeType>(this IEnumerable<ItemToBuildSpecificationOn> items, PropertyAccessor<ItemToBuildSpecificationOn, AttributeType> accessor)
    {
        return new ItemsToMatch<ItemToBuildSpecificationOn, AttributeType>(Match<ItemToBuildSpecificationOn>.attribute(accessor), items);
    }

    public static IEnumerable<ItemToBuildSpecificationOn>
         equal_to<ItemToBuildSpecificationOn, AttributeType>(this ItemsToMatch<ItemToBuildSpecificationOn, AttributeType> temp, AttributeType attributeType)
    {
        foreach (var item in temp.items)
        {
            var match = temp.entensionPoint.equal_to(attributeType);
            if (match.matches(item))
                yield return item;
        }
    }
  }

  public class ItemsToMatch<ItemToBuildSpecificationOn, AttributeType>
  {
      public IProvideAccessToCreatingMatchers<ItemToBuildSpecificationOn, AttributeType> entensionPoint;
      public IEnumerable<ItemToBuildSpecificationOn> items;

      public ItemsToMatch(IProvideAccessToCreatingMatchers<ItemToBuildSpecificationOn, AttributeType> entensionPoint, IEnumerable<ItemToBuildSpecificationOn> items)
      {
          this.entensionPoint = entensionPoint;
          this.items = items;
      }
  }

}