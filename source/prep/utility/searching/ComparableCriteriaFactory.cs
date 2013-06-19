using System;
using prep.collections;

namespace prep.utility.searching
{
  public class ComparableCriteriaFactory<ItemToBuildSpecificationOn, PropertyType> 
      : ICriteriaFactory<ItemToBuildSpecificationOn, PropertyType>,
      IComparableCriteriaFactory<ItemToBuildSpecificationOn, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor;
      private ICriteriaFactory<ItemToBuildSpecificationOn, PropertyType> criteriaFactory;

      public ComparableCriteriaFactory(PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor,
            ICriteriaFactory<ItemToBuildSpecificationOn, PropertyType> criteriaFactory)
    {
      this.accessor = accessor;
        this.criteriaFactory = criteriaFactory;
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
        return criteriaFactory.equal_to(value);
    }

    public IMatchA<ItemToBuildSpecificationOn> equal_to_any(params PropertyType[] values)
    {
        return criteriaFactory.equal_to_any(values);
    }

    public IMatchA<ItemToBuildSpecificationOn> not_equal_to(PropertyType value)
    {
        return criteriaFactory.not_equal_to(value);
    }
  }
}