using System;

namespace prep.utility.searching
{
    public interface IComparableCriteriaFactory<ItemToBuildSpecificationOn, PropertyType> 
        where PropertyType : IComparable<PropertyType>
    {
        IMatchA<ItemToBuildSpecificationOn> greater_than(PropertyType comparison_value);
        IMatchA<ItemToBuildSpecificationOn> between(PropertyType start, PropertyType end);
    }
}