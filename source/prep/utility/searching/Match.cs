using System;

namespace prep.utility.searching
{
  public class Match<ItemToBuildSpecificationOn>
  {
    public static MatchFactory<ItemToBuildSpecificationOn, PropertyType> attribute<PropertyType>(
      PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor)
    {
        return new MatchFactory<ItemToBuildSpecificationOn, PropertyType>(accessor);
    }

    public static ComparableMatchFactory<ItemToBuildSpecificationOn,PropertyType> 
        comparable_attribute<PropertyType>(PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor ) 
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparableMatchFactory<ItemToBuildSpecificationOn, PropertyType>(attribute(accessor));
    }
  }
}