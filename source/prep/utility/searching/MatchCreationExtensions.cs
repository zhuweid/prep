using System;

namespace prep.utility.searching
{
  public static class MatchCreationExtensions
  {
    public static IMatchA<Target> equal_to<Target,PropertyType>(this IProvideAccessToCreatingMatchers<Target,PropertyType> extension_point, PropertyType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static IMatchA<Target> create_from_condition<Target,PropertyType>(this IProvideAccessToCreatingMatchers<Target,PropertyType> extension_point, Criteria<Target> condition)
    {
      return new AnonymousMatch<Target>(condition);
    }

    public static IMatchA<Target> equal_to_any<Target,PropertyType>(this IProvideAccessToCreatingMatchers<Target,PropertyType> extension_point, params PropertyType[] values)
    {
      return create_from_attribute_criteria(extension_point, new IsEqualToAny<PropertyType>(values));
    }

    public static IMatchA<Target> create_from_attribute_criteria<Target,PropertyType>(this IProvideAccessToCreatingMatchers<Target,PropertyType> extension_point, IMatchA<PropertyType> condition)
    {
      return extension_point.create_matcher(condition);
    }

    public static IMatchA<Target> not_equal_to<Target,PropertyType>(this IProvideAccessToCreatingMatchers<Target,PropertyType> extension_point, PropertyType value)
    {
      return equal_to(extension_point, value).not();
    }

    public static IMatchA<Target> greater_than<Target, PropertyType>(this IProvideAccessToCreatingMatchers<Target, PropertyType> extension_point, PropertyType comparison_value)
     where PropertyType : IComparable<PropertyType>
    {
        return create_from_attribute_criteria(extension_point, new IsGreaterThan<PropertyType>(comparison_value));
    }

    public static IMatchA<Target> between<Target,PropertyType>(this IProvideAccessToCreatingMatchers<Target,PropertyType> extension_point, PropertyType start, PropertyType end) 
      where PropertyType : IComparable<PropertyType>
    {
      return create_from_attribute_criteria(extension_point, new IsBetween<PropertyType>(start, end));
    }
  }
}
