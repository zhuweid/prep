namespace prep.utility.searching
{
  public class MatchFactory<Target, PropertyType> : IBuildMatchers<Target, PropertyType>
  {
    PropertyAccessor<Target, PropertyType> accessor;

    public MatchFactory(PropertyAccessor<Target, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<Target> equal_to(PropertyType value)
    {
      return equal_to_any(value);
    }

    public IMatchA<Target> create_from_condition(Criteria<Target> condition)
    {
      return new AnonymousMatch<Target>(condition);
    }

    public IMatchA<Target> equal_to_any(params PropertyType[] values)
    {
      return create_from_attribute_criteria(new IsEqualToAny<PropertyType>(values));
    }

    public IMatchA<Target> create_from_attribute_criteria(IMatchA<PropertyType> condition)
    {
      return new AttributeMatch<Target, PropertyType>(accessor, condition);
    }

    public IMatchA<Target> not_equal_to(PropertyType value)
    {
      return equal_to(value).not();
    }
  }
}