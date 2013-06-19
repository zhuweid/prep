using System;
using prep.collections;

namespace prep.utility.searching
{
  public class ComparableCriteriaFactory<ItemToBuildSpecificationOn, PropertyType>
    where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor;

    public ComparableCriteriaFactory(PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToBuildSpecificationOn> greater_than(PropertyType comparison_value)
    {
      return new AnonymousMatch<ItemToBuildSpecificationOn>(x =>
      {
        var value = accessor(x);
        var result = value.CompareTo(comparison_value);
        return result > 0;
      });
    }

    public IMatchA<ItemToBuildSpecificationOn> between(PropertyType start, PropertyType end)
    {
      return new AnonymousMatch<ItemToBuildSpecificationOn>(x =>
      {
        var value = accessor(x);

        return value.CompareTo(start) >= 0 &&
          value.CompareTo(end) <= 0;
      });
    }
  }
}