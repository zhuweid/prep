using System;

namespace prep.utility.searching
{
  public class Match<ItemToBuildSpecificationOn>
  {
    public static CriteriaFactory<ItemToBuildSpecificationOn, PropertyType> attribute<PropertyType>(
      PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor)
    {
      return new CriteriaFactory<ItemToBuildSpecificationOn, PropertyType>(accessor);
    }

    public static ComparableCriteriaFactory<ItemToBuildSpecificationOn,PropertyType> 
        comparable_attribute<PropertyType>(PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor ) 
      where PropertyType : IComparable<PropertyType>
    {
      return new ComparableCriteriaFactory<ItemToBuildSpecificationOn, PropertyType>(accessor, 
          attribute(accessor));
    }
  }
}