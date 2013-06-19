using System;

namespace prep.utility.searching
{
  public class ComparableMatchFactory<ItemToBuildSpecificationOn, PropertyType>
    : IBuildMatchers<ItemToBuildSpecificationOn, PropertyType>
    where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor;
    IBuildMatchers<ItemToBuildSpecificationOn, PropertyType> criteria_factory;

    public ComparableMatchFactory(PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor,
                                  IBuildMatchers<ItemToBuildSpecificationOn, PropertyType> criteria_factory)
    {
      this.accessor = accessor;
      this.criteria_factory = criteria_factory;
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

    public IMatchA<ItemToBuildSpecificationOn> equal_to(PropertyType value)
    {
      return criteria_factory.equal_to(value);
    }

    public IMatchA<ItemToBuildSpecificationOn> equal_to_any(params PropertyType[] values)
    {
      return criteria_factory.equal_to_any(values);
    }

    public IMatchA<ItemToBuildSpecificationOn> not_equal_to(PropertyType value)
    {
      return criteria_factory.not_equal_to(value);
    }
  }
}