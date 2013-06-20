using System.Collections;
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

    public static IOrderedEnumerable<Target> sort_by<Target, AttributeType>
        (this IEnumerable<Target> movies, PropertyAccessor<Target, AttributeType> accessor)
    {
        return new SortingExtensionPoint<Target, AttributeType>(movies, accessor).sort().ToResult();
    }

    public static IOrderedEnumerable<Target> sort_by_decending<Target, AttributeType>
        (this IEnumerable<Target> movies, PropertyAccessor<Target, AttributeType> accessor)
    {
        return new SortingExtensionPoint<Target, AttributeType>(movies, accessor).sort().decending().ToResult();
    }

    public static IOrderedEnumerable<Target> then_by<Target, AttributeType>
      (this IOrderedEnumerable<Target> movies, PropertyAccessor<Target, AttributeType> accessor)
    {
        return new SortingExtensionPoint<Target, AttributeType>(movies, accessor, movies.sortFactors).thenby().ToResult();
    }

    public static IOrderedEnumerable<Target> then_by_decending<Target, AttributeType>
    (this IOrderedEnumerable<Target> movies, PropertyAccessor<Target, AttributeType> accessor)
    {
        return new SortingExtensionPoint<Target, AttributeType>(movies, accessor, movies.sortFactors).thenby().decending().ToResult();
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

    public class SortFactor
    {
        public string attributeName { get; set; }
        public bool isDencending { get; set; }
    }

    public interface IOrderedEnumerable<out Target> : IEnumerable<Target>
    {
        List<SortFactor> sortFactors { get; }
    }

    public class SortingExtensionPoint<Target, AttributeType>
    {
        public readonly IEnumerable<Target> items;
        public readonly PropertyAccessor<Target, AttributeType> accessor;


        public SortingExtensionPoint(IEnumerable<Target> items, PropertyAccessor<Target, AttributeType> accessor)
        {
          this.items = items;
          this.accessor = accessor;
        }

        public SortingExtensionPoint(IEnumerable<Target> items, PropertyAccessor<Target, AttributeType> accessor, List<SortFactor> existingFactors)
        {
            this.items = items;
            this.accessor = accessor;
        }

        public SortingExtensionPoint<Target, AttributeType> sort()
        {

            return this;
        }

        public SortingExtensionPoint<Target, AttributeType> thenby()
        {

            return this;
        }

        public SortingExtensionPoint<Target, AttributeType> decending()
        {
            
        }

        public IOrderedEnumerable<Target> ToResult()
        {
            return null;
        }
    }


}