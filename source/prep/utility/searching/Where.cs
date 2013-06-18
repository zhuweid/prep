namespace prep.utility.searching
{
  public class Where<TTarget>
  {
    public static PropertyAccessor<TTarget, TPropertyType> has_a<TPropertyType>(
      PropertyAccessor<TTarget, TPropertyType> accessor)
    {
      return accessor;
    }
  }

  public static class AccessorExtensions
  {
    public static IMatchA<TTarget> equal_to<TTarget, TPropertyType>(
      this PropertyAccessor<TTarget, TPropertyType> accessor, TPropertyType value)
    {
      return new AnonymousMatch<TTarget>(x =>
      {
        var property_value = accessor(x);
        return property_value.Equals(value);
      });
    }
  }
}