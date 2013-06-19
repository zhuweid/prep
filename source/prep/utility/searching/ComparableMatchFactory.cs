using System;

namespace prep.utility.searching
{
  public class ComparableMatchFactory<ItemToBuildSpecificationOn, PropertyType>
    : IBuildMatchers<ItemToBuildSpecificationOn, PropertyType>
    where PropertyType : IComparable<PropertyType>
  {
    IBuildMatchers<ItemToBuildSpecificationOn, PropertyType> criteria_factory;

    public ComparableMatchFactory(IBuildMatchers<ItemToBuildSpecificationOn, PropertyType> criteria_factory)
    {
      this.criteria_factory = criteria_factory;
    }

    public IMatchA<ItemToBuildSpecificationOn> create_from_condition(Criteria<ItemToBuildSpecificationOn> condition)
    {
      return criteria_factory.create_from_condition(condition);
    }

    public IMatchA<ItemToBuildSpecificationOn> create_from_attribute_criteria(IMatchA<PropertyType> condition)
    {
      return criteria_factory.create_from_attribute_criteria(condition);
    }

    public IMatchA<ItemToBuildSpecificationOn> greater_than(PropertyType comparison_value)
    {
      return create_from_attribute_criteria(new IsGreaterThan<PropertyType>(comparison_value));
    }

    public IMatchA<ItemToBuildSpecificationOn> between(PropertyType start, PropertyType end)
    {
      return create_from_attribute_criteria(new IsBetween<PropertyType>(start, end));
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