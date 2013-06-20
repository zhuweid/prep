using System.Collections.Generic;

namespace prep.utility.searching
{
  public static class IEnumerableExtensions
  {
    public static CollectionFilteringExtensionPoint<Target, AttributeType> where<Target, AttributeType>
      (this IEnumerable<Target> movies, PropertyAccessor<Target, AttributeType> accessor)
    {
      return new CollectionFilteringExtensionPoint<Target, AttributeType>(movies, accessor);
    }
  }

  public static class CollectionFilteringExtensions
  {
    public static IEnumerable<Target> equal_to<Target, AttributeType>(
      this CollectionFilteringExtensionPoint<Target, AttributeType> extension_point,
      AttributeType value)
    {
      var criteria = Match<Target>.attribute(extension_point.accessor).equal_to(value);
      return extension_point.filter_using_criteria(criteria);
    }
  }

  public class CollectionFilteringExtensionPoint<Target, AttributeType>
  {
    public readonly IEnumerable<Target> items;
    public readonly PropertyAccessor<Target, AttributeType> accessor;
    public MatchCreationExtensionPoint<Target, AttributeType> _internalMatchCreationXtnPoint;

    public CollectionFilteringExtensionPoint(IEnumerable<Target> items, PropertyAccessor<Target, AttributeType> accessor)
    {
      this.items = items;
      this.accessor = accessor;
    }

    public IEnumerable<Target> filter_using_criteria(IMatchA<Target> criteria)
    {
      return items.all_items_matching(criteria);
    }
  }
}