using System;

namespace prep.utility.searching
{
  public class CriteriaFactory<Target, PropertyType>
  {
    PropertyAccessor<Target, PropertyType> accessor;

    public CriteriaFactory(PropertyAccessor<Target, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<Target> equal_to(PropertyType value)
    {
      return new AnonymousMatch<Target>(x => value.Equals(accessor(x)));
    }

    public IMatchA<Target> equal_to_any(params PropertyType[] values)
    {
      throw new NotImplementedException();
    }
  }
}